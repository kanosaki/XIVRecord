﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XIVRecord.Video;

namespace XIVRecord.ViewModels
{
    public class RecordViewModel : ViewModelBase
    {
        VideoRecord _model;
        public RecordViewModel(VideoRecord model)
        {
            _model = model;
        }
    }
}
