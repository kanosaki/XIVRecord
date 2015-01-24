using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XIVRecord.ActLog
{
    public class LogFile
    {
        const string TIMESTAMP_PATTERN_BEGIN = "yyyyMMdd";
        const string TIMESTAMP_PATTERN_END = "yyyy.MM.dd";
        static readonly Regex FILENAME_PATTERN = new Regex(@"Network_(?<begin>\d{8})\.((?<end>\d{4}\.\d{2}\.\d{2})(\.))?log", RegexOptions.Compiled);
        public FileInfo File { get; protected set; }
        public DateRange TimeRange { get; private set; }
        public bool BodyLoaded { get; protected set; }

        public LogFile(FileInfo fi)
        {
            this.File = fi;
            this.ShallowInit();
        }

        protected void ShallowInit()
        {
            var filename = this.File.Name;
            var match = FILENAME_PATTERN.Match(filename);
            if (!match.Success)
                throw new ArgumentException(this.File.FullName + " is not a valid LogFile");
            var begin = DateTime.ParseExact(
                match.Groups["begin"].Value,
                TIMESTAMP_PATTERN_BEGIN,
                DateTimeFormatInfo.InvariantInfo);
            var endgroup = match.Groups["end"];
            var end = (endgroup != null && !string.IsNullOrWhiteSpace(endgroup.Value))
                ? DateTime.ParseExact(
                    endgroup.Value,
                    TIMESTAMP_PATTERN_END,
                    DateTimeFormatInfo.InvariantInfo)
                 : begin + TimeSpan.FromDays(1);
            this.TimeRange = new DateRange(begin, end);
            this.BodyLoaded = false;
        }
    }
}
