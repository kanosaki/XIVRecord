using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    public class RecordViewModel : ViewModelBase
    {
        Record _model;
        public RecordViewModel(Record model)
        {
            _model = model;
        }
    }
}
