using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVRecord.Video;

namespace XIVRecord
{
    public class Main
    {
        public VideoArchiveDir Archive { get; private set; }
        public string ArchivePath
        {
            get
            {
                return this.Archive != null
                    ? this.Archive.Dir.FullName
                    : null;
            }
            set
            {
                this.Archive = new VideoArchiveDir(new System.IO.DirectoryInfo(value));
            }
        }

        public Main()
        {
            this.Archive = VideoArchiveDir.TryReadFromRegistry();
            var logfiles = ActLog.Act.Default.FFXIVLogDir.Find(DateRange.Create(DateTime.Now, TimeSpan.FromDays(-1)));
            foreach (var log in logfiles)
            {
                Console.WriteLine(log.File.FullName);
            }
        }
    }
}
