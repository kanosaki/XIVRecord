using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        Main _model;

        public ArchiveDirViewModel ArchiveDir { get; set; }

        public MainViewModel()
        {
            _model = new Main();
        }
    }
}
