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
        ArchiveDir _videoDir;
        LogDir _logDir;

        public BattleArchive(ArchiveDir videoDir, LogDir logDir)
        {
            if (videoDir == null)
                throw new NullReferenceException("videoDir");
            if (logDir == null)
                throw new NullReferenceException("logDir");
            _videoDir = videoDir;
            _logDir = logDir;
            this.Records = new List<BattleRecord>();
        }

        public List<BattleRecord> Records { get; set; }

        public IEnumerator<BattleRecord> GetEnumerator()
        {
            return this.Records.ToList().GetEnumerator();
        }

        public static BattleArchive LoadDefault()
        {
            var videoDir = ArchiveDir.TryReadFromRegistry();
            var logDir = Act.Default.FFXIVLogDir;
            return new BattleArchive(videoDir, logDir);
        }
    }
}
