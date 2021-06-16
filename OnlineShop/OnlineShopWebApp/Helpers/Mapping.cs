using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
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
        public static CompareViewModel ToCompareViewModel(Compare compare)
        {
            if (compare == null)
            {
                return null;
            }
            return new CompareViewModel
            {
                Id = compare.Id,
                UserId = compare.UserId,
                Items = ToProductViewModels(compare.Items)
            };
        }
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static FavoritesViewModel ToFavoritesViewModel(Favorites favorite)
        {
            if (favorite == null)
            {
                return null;
            }
            return new FavoritesViewModel
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                Items = ToProductViewModels(favorite.Items)
            };
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
        public static int ToIntStatus(string status)
        {
            switch (status)
            {
                case "Создан":
                    return 1;
                case "В работе":
                    return 2;
                case "В пути":
                    return 3;
                case "Готов к выдаче":
                    return 4;
                case "Выполнен":
                    return 5;
                case "Отменен":
                    return 6;
                case "Ошибка":
                    return 0;
            }
            return 0;
        }
        public static UserViewModel ToUserViewModel(this User userDb)
        {
            var userVM = new UserViewModel();
            userVM.Id = userDb.Id;
            userVM.Login.Name = userDb.UserName;
            return userVM;
        }
    }
}
