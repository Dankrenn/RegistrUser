using RegistrUserWPF.Enums.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserWPF.Enums.EnumDescriprionViewModel
{
    public class EnumValuesProvider : IEnumValuesProvider
    {
        private readonly IEnumDescriptionProvider _descriptionProvider;

        public EnumValuesProvider(IEnumDescriptionProvider descriptionProvider)
        {
            _descriptionProvider = descriptionProvider;
        }


        public IEnumerable<EnumViewModel<TEnum>> GetValues<TEnum>()
            where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            foreach (TEnum value in values)
            {
                var description = _descriptionProvider.GetDescription(value);
                yield return new EnumViewModel<TEnum>(value, description);
            }
        }
    }
}
