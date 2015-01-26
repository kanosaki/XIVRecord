using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVRecord.ActLog;
using XIVRecord.Video;

namespace XIVRecord
{
    public class BattleArchive
    {
        VideoArchiveDir _videoDir;
        LogDir _logDir;

        public BattleArchive(VideoArchiveDir videoDir, LogDir logDir)
        {
            if (videoDir == null)
                throw new NullReferenceException("videoDir");
            if (logDir == null)
                throw new NullReferenceException("logDir");
            _videoDir = videoDir;
            _logDir = logDir;
            this.Records = this.CollectRecords();
        }

        public List<BattleRecord> Records { get; set; }

        private List<BattleRecord> CollectRecords()
        {
            return _videoDir
                .EnumerateRecords()
                .Select(rec =>
                {
                    var logs = _logDir.Find(DateRange.Create(rec.Timestamp, TimeSpan.FromSeconds(0)));
                    if (logs.Any())
                        return new BattleRecord(new BattleLog(logs.ToList()), new BattleVideo(rec));
                    else
                        return null;

                })
                .Where(e => e != null)
                .ToList();
        }

        public IEnumerator<BattleRecord> GetEnumerator()
        {
            return this.Records.ToList().GetEnumerator();
        }

        public static BattleArchive LoadDefault()
        {
            var videoDir = VideoArchiveDir.TryReadFromRegistry();
            var logDir = Act.Default.FFXIVLogDir;
            return new BattleArchive(videoDir, logDir);
        }
    }
}
