using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserWPF.Enums.EnumDescriprionViewModel
{
    public static class IEnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> src)
        {
            return new ObservableCollection<T>(src);
        }
    }
}
