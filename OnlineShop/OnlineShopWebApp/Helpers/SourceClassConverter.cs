using System.ComponentModel;
using System.Globalization;
using System;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class SourceClassConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(ProductViewModel);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (ProductViewModel)value;
            var result = new ProductViewModel
            {
                Name = concreteValue.Name,
                Cost = concreteValue.Cost,
                Description = concreteValue.Description,
                Id = concreteValue.Id,
                Images = concreteValue.Images
            };
            return result;
        }
    }
}
