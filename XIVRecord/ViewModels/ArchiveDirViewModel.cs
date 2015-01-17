using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    public class ArchiveDirViewModel : ViewModelBase
    {
        ArchiveDir _model;
        public ObservableCollection<RecordViewModel> Records { get; set; }

        public ArchiveDirViewModel(ArchiveDir model)
        {
            _model = model;
            this.Refresh();
        }

        public void Refresh()
        {
            var records = _model
                .EnumerateRecords()
                .Select(rec => new RecordViewModel(rec));
            this.Records = new ObservableCollection<RecordViewModel>(records); 
        }
    }
}
