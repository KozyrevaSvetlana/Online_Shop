using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using Nelibur.ObjectMapper;
using System;
using System.ComponentModel;
using System.Globalization;

namespace ModelsLibrary.Converters
{
    public class CartItemConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(CartItemViewModel);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concretedValue = (CartItem)value;
            var result = new CartItemViewModel
            {
                Id = concretedValue.Id,
                Amount = concretedValue.Amount,
                Product = TinyMapper.Map<ProductViewModel>(concretedValue.Product)
            };
            return result;
        }
    }
}
