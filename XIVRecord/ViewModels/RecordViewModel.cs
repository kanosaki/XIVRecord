using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XIVRecord.Video;

namespace XIVRecord.ViewModels
{
    public class RecordViewModel : PageViewModelBase
    {
        VideoRecord _model;
        public RecordViewModel(VideoRecord model)
        {
            _model = model;
            PlayCommand = new RelayCommand(this.Play, this.CanPlay);
        }

        public DateTime Timestamp { get { return _model.Timestamp; } }

        public string Caption { get { return _model.HeadFile.Name; } }


        public void Play()
        {
            this.Navigate("/Views/PlayRecordView.xaml", new PlayRecordViewModel(null));
        }

        public bool CanPlay()
        {
            return true;
        }

        public ICommand PlayCommand { get; private set; }
    }
}
