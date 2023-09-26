using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserWPF.Enums.EnumDescriprionViewModel
{
    public class EnumViewModel<TEnum> where TEnum : Enum
    {
        public TEnum Value { get; set; }
        public string Description { get;}

        public EnumViewModel(TEnum value, string description)
        {
            Value = value;
            Description = description;
        }
    }
}
