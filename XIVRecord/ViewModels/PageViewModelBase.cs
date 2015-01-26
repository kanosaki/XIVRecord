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

        protected void Navigate(Uri pageUri, object datacontext)
        {
            MessengerInstance.Send(new NavigatePageMassage(pageUri, datacontext));
        }
    }
}
