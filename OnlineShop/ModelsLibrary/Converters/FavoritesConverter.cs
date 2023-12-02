using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using Nelibur.ObjectMapper;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ModelsLibrary.Converters
{
    public class FavoritesConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(FavoritesViewModel);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (Favorites)value;
            var result = new FavoritesViewModel
            {
                Id = concreteValue.Id,
                Items = concreteValue.Items.Select(x => TinyMapper.Map<ProductViewModel>(x)).ToList(),
                UserId = concreteValue.UserId
            };
            return result;
        }
    }
}
