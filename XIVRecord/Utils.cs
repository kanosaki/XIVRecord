using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XIVRecord
{
    public interface IRange<T>
    {
        T Start { get; }
        T End { get; }
        bool Includes(T value);
        bool Includes(IRange<T> range);
        bool Intersects(IRange<DateTime> range);
    }

    public class NavigatePageMassage
    {
        public Uri Uri { get; private set; }
        public FrameworkElement Source { get; private set; }
        public string Param { get; private set; }

        public NavigatePageMassage(Uri uri, FrameworkElement source = null, string param = null)
        {
            this.Uri = uri;
            this.Source = source;
            this.Param = param;
        }

        public static NavigatePageMassage Create(
            string relativeUri,
            FrameworkElement source = null,
            string param = null)
        {
            return new NavigatePageMassage(new Uri(relativeUri, UriKind.RelativeOrAbsolute), source, param);
        }
    }
}
