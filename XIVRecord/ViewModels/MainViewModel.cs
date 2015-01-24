using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
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
            Task.Run((Action)this.Init)
                .ContinueWith(task =>
                {
                    this.RaisePropertyChanged();
                });
        }

        private void Init()
        {
            _model = new Main();
            this.ArchiveDir = new ArchiveDirViewModel(_model.Archive);
        }
    }
}
