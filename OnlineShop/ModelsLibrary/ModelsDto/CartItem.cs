using ModelsLibrary.Converters;
using System;
using System.ComponentModel;

namespace ModelsLibrary.ModelsDto
{
    [TypeConverter(typeof(CartItemConverter))]
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        public UserContact UserContact { get; set; }
    }
}
