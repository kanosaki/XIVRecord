using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.Video
{
    public class BattleVideo
    {
        VideoRecord _rec;
        public DateTime Timestamp { get { return _rec.Timestamp; } }

        public BattleVideo(VideoRecord rec)
        {
            _rec = rec;
        }
    }
}
