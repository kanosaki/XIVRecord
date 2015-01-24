using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ActLog
{
    public class LogDir
    {
        public DirectoryInfo Dir { get; private set; }
        public LogDir(DirectoryInfo dir)
        {
            this.Dir = dir;
        }

        /// <summary>
        /// Find LogFile by time range.
        /// </summary>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time. You can specify same value as 'start'</param>
        /// <returns></returns>
        public IEnumerable<LogFile> Find(DateRange range)
        {
            return this.Dir
                .EnumerateFiles("Network_*.log")
                .Select(fi => new LogFile(fi))
                .Where(log => log.TimeRange.Intersects(range));
        }
    }
}
