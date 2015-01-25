using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    public class MainWindowViewModel : PageViewModelBase
    {
        Main _model;
        public ArchiveDirViewModel ArchiveDir { get; set; }

        public MainWindowViewModel()
        {
            Task.Run((Action)this.Init)
                .ContinueWith(task =>
                {
                    this.NavigateToDefaultPage();
                });
        }

        private void Init()
        {
            _model = new Main();
            this.ArchiveDir = new ArchiveDirViewModel(_model.Archive);
        }

        private void NavigateToDefaultPage()
        {
            this.Navigate("/Views/ArchiveDirView.xaml", this.ArchiveDir);
        }

        object _contentContext;
        public object ContentContext
        {
            get
            {
                return _contentContext;
            }
            set
            {
                if (_contentContext == value) return;
                _contentContext = value;
                this.RaisePropertyChanged(() => this.ContentContext);
            }
        }
    }
}
