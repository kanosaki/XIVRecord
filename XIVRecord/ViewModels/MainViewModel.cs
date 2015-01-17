using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    class MainViewModel
    {
        public MainViewModel()
        {
            var dir = ArchiveDir.TryReadFromRegistry();
            var recs = dir.EnumerateRecords().ToList();
        }
    }
}
