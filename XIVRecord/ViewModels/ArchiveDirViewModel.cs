using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVRecord.Video;

namespace XIVRecord.ViewModels
{
    public class BattleArchiveViewModel : ViewModelBase
    {
        BattleArchive _model;
        public ObservableCollection<RecordViewModel> Records { get; set; }

        public BattleArchiveViewModel(BattleArchive model)
        {
            _model = model;
            this.Refresh();
        }

        public void Refresh()
        {
            var vms = _model.Select(br => new RecordViewModel(br));
            this.Records = new ObservableCollection<RecordViewModel>(vms); 
        }
    }
}
