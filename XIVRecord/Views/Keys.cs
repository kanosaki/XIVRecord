using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.Views
{
    public static class ViewKeys
    {
        public static readonly Uri PlayRecordView = uri("/Views/PlayRecordView.xaml");
        public static readonly Uri ArchiveDirView = uri("/Views/ArchiveDirView.xaml");

        private static Uri uri(string relUri)
        {
            return new Uri(relUri, UriKind.RelativeOrAbsolute);
        }
    }
}
