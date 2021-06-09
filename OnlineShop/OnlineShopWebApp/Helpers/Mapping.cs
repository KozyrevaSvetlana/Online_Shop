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
            orderDb.UserContacts.Name = order.User.Name;
            orderDb.UserContacts.Surname = order.User.Surname;
            orderDb.UserContacts.Adress = order.User.Adress;
            orderDb.UserContacts.Phone = order.User.Phone;
            orderDb.UserContacts.Email = order.User.Email;
            orderDb.InfoStatus = (int)order.InfoStatus.StatusOrder;
            return orderDb;
        }
        public static OrderViewModel ToOrderViewModels(Order orderDb)
        {
            var orderViewModels = new OrderViewModel()
            {
                Number = orderDb.Number,
                Comment = orderDb.Comment,
                UserId = orderDb.UserId,
                User = new UserContactViewModel()
            };
            orderViewModels.User.Name = orderDb.UserContacts.Name;
            orderViewModels.User.Surname = orderDb.UserContacts.Surname;
            orderViewModels.User.Adress = orderDb.UserContacts.Adress;
            orderViewModels.User.Phone = orderDb.UserContacts.Phone;
            orderViewModels.User.Email = orderDb.UserContacts.Email;
            orderViewModels.InfoStatus.StatusOrder = (Statuses)orderDb.InfoStatus;
            orderViewModels.Products = ToCartItemViewModels(orderDb.Items);
            return orderViewModels;
        }


        public static List<OrderViewModel> ToOrdersViewModels(List<Order> ordersDb)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var orderDb in ordersDb)
            {
                ordersViewModel.Add(ToOrderViewModels(orderDb));
            }
            return ordersViewModel;
        }

        public static List<OrderViewModel> ToOrdersViewModels(IEnumerable<Order> orders)
        {
            var ordersViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModels.Add(ToOrderViewModels(order));
            }
            return ordersViewModels;
        }
    }
}
