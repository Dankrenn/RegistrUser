using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserWPF.Enums.EnumDescriprionViewModel
{
    public interface IEnumValuesProvider
    {
        IEnumerable<EnumViewModel<TEnum>> GetValues<TEnum>() where TEnum : Enum;
    }
}
