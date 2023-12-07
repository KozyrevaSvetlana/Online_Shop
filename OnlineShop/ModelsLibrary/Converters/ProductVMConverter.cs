using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ModelsLibrary.Converters
{
    public class ProductVMConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(Product);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (ProductViewModel)value;
            var result = new Product
            {
                Name = concreteValue.Name,
                Cost = concreteValue.Cost,
                Description = concreteValue.Description,
                Id = concreteValue.Id,
                Images = concreteValue.Images.Select(x => new Image { Url = x }).ToList()
            };
            return result;
        }
    }
}
