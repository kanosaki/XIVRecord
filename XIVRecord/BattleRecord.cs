using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVRecord.ActLog;
using XIVRecord.Video;

namespace XIVRecord
{
    public class BattleRecord
    {
        public BattleLog Log { get; protected set; }
        public BattleVideo Video { get; protected set; }

        public BattleRecord(BattleLog log, BattleVideo video)
        {
            this.Log = log;
            this.Video = video;
        }
    }
}
