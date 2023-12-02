using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using Nelibur.ObjectMapper;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ModelsLibrary.Converters
{
    public class CompareConverterConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(CompareViewModel);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (Compare)value;
            var result = new CompareViewModel
            {
                Id = concreteValue.Id,
                Items = concreteValue.Items.Select(x => TinyMapper.Map<ProductViewModel>(x)).ToList(),
                UserId = concreteValue.UserId
            };
            return result;
        }
    }
}
