using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    public class PlayRecordViewModel : ViewModelBase
    {
        BattleRecord _model;

        public PlayRecordViewModel(BattleRecord model)
        {
            this.Caption = "FOOBAR";
            //if (model == null) 
            //    throw new ArgumentNullException("model");
            //_model = model;
        }

        public string Caption { get; set; }
    }
}
