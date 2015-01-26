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
        public static readonly TimeSpan UpdateInterval = TimeSpan.FromMinutes(10);

        List<LogFile> _files;
        DateTime _lastChecked;

        public LogDir(DirectoryInfo dir)
        {
            this.Dir = dir;
        }

        private void RefreshFiles()
        {
            _files = this.Dir
                .EnumerateFiles("Network_*.log")
                .Select(fi => new LogFile(fi)).ToList();
            _lastChecked = DateTime.Now;
        }

        private void CheckFiles()
        {
            if (_files == null || DateTime.Now - _lastChecked > UpdateInterval)
                this.RefreshFiles();
        }

        /// <summary>
        /// Find LogFile by time range.
        /// </summary>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time. You can specify same value as 'start'</param>
        /// <returns></returns>
        public IEnumerable<LogFile> Find(DateRange range)
        {
            this.CheckFiles();
            return _files.Where(log => log.TimeRange.Intersects(range));
        }
    }
}
