using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XIVRecord.Video
{
    public class VideoRecord
    {
        // Desktop 01.16.2015 - 21.35.39.06.DVR.mp4
        static readonly Regex FILENAME_PATTERN = new Regex(@"\w+ (\d{2}\.\d{2}\.\d{4} - \d{2}\.\d{2}\.\d{2}\.\d{2})(?:\.DVR)?\.mp4", RegexOptions.Compiled);
        const string TIMESTAMP_PATTERN = "MM.dd.yyyy - HH.mm.ss.ff";
        public List<FileInfo> Files { get; private set; }
        public FileInfo HeadFile { get { return this.Files.First(); } }
        public DateTime Timestamp { get; private set; }

        public VideoRecord(FileInfo headFile)
        {
            if (!headFile.Exists)
                throw new ArgumentException(string.Format("{0} not exisis", headFile));
            var match = FILENAME_PATTERN.Match(headFile.Name);
            if (!match.Success)
                throw new ArgumentException("Invalid record:" + headFile);
            this.Timestamp = DateTime.ParseExact(match.Groups[1].Value,
                TIMESTAMP_PATTERN,
                DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.None);
            this.Files = this.GatherRecordFiles(headFile);
        }

        /// <summary>
        /// Gather video groups.
        /// 
        /// A long record will be splitted by ShadowPlay.
        /// This method gather all videos.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        protected List<FileInfo> GatherRecordFiles(FileInfo head)
        {
            string basename = Path.GetFileNameWithoutExtension(head.FullName);
            string extension = head.Extension;
            string dir = head.DirectoryName;
            var ret = new List<FileInfo>();
            ret.Add(head);
            for (int i = 1; ; i++)
            {
                var filename = string.Format("{0}_{1}.{2}", basename, i, extension);
                var followingCandidate = new FileInfo(Path.Combine(dir, filename));
                if (followingCandidate.Exists)
                    ret.Add(followingCandidate);
                else
                    break;
            }
            return ret;
        }
    }
}
