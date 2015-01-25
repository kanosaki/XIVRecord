using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.ViewModels
{
    public class PageViewModelBase : ViewModelBase
    {
        protected void Navigate(string pageUri, object datacontext)
        {
            MessengerInstance.Send(NavigatePageMassage.Create(pageUri, datacontext));
        }
    }
}
