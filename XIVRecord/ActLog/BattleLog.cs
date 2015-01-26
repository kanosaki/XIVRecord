using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ActLog
{
    public class BattleLog
    {
        List<LogFile> _logCandidates;
        public BattleLog(List<LogFile> logCandidates)
        {
            _logCandidates = logCandidates;
        }
    }
}
