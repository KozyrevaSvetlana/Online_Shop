using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ModelsLibrary.Converters
{
    public class AddProductViewModelConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(Product);
        }
        public object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType, List<string> images)
        {
            var concreteValue = (AddProductViewModel)value;
            var result = new Product
            {
                Name = concreteValue.Name,
                Cost = concreteValue.Cost,
                Description = concreteValue.Description,
                Images = images.Select(x => new Image { Url = x }).ToList()
            };
            return result;
        }
    }
}
