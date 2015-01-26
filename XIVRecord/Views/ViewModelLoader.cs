using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVRecord.Views
{
    public class ViewModelLoader
    {
        static ViewModelLoader _instance = new ViewModelLoader();
        public static ViewModelLoader Default { get { return _instance; } }

        Dictionary<object, object> _map;

        public ViewModelLoader()
        {
            _map = new Dictionary<object, object>();
        }

        public void Update(object key, object value)
        {
            _map[key] = value;
        }

        public object Get(object key)
        {
            object ret = null;
            _map.TryGetValue(key, out ret);
            return ret;
        }
    }
}
