using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OnlineShopWebApp.Models.InfoStatusOrderViewModel;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(IEnumerable<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Image = product.Image
            };
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
        public static Order ToOrder(OrderViewModel order)
        {
            var orderDb = new Order()
            {
                Number = order.Number,
                Comment = order.Comment,
                UserId = order.UserId,
            };
            orderDb.User.Name = order.User.Name;
            orderDb.User.Surname = order.User.Surname;
            orderDb.User.Adress = order.User.Adress;
            orderDb.User.Phone = order.User.Phone;
            orderDb.User.Email = order.User.Email;
            orderDb.InfoStatus.StatusOrder = (int)order.InfoStatus.StatusOrder;
            return orderDb;
        }
        public static OrderViewModel ToOrderViewModels(Order orderDb)
        {
            var orderViewModels = new OrderViewModel()
            {
                Number = orderDb.Number,
                Comment = orderDb.Comment,
                UserId = orderDb.UserId,
            };
            orderViewModels.User.Name = orderDb.User.Name;
            orderViewModels.User.Surname = orderDb.User.Surname;
            orderViewModels.User.Adress = orderDb.User.Adress;
            orderViewModels.User.Phone = orderDb.User.Phone;
            orderViewModels.User.Email = orderDb.User.Email;
            orderViewModels.InfoStatus.StatusOrder = (Status)orderDb.InfoStatus.StatusOrder;
            return orderViewModels;
        }
    }
}
