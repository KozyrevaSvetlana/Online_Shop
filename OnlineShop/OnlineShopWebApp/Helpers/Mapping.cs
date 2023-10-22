using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using static OnlineShopWebApp.Models.InfoStatusOrderViewModel;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this IEnumerable<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Images = product.Images.Select(x => x.Url).ToList()
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
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

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
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
        public static Order ToOrder(this OrderViewModel order)
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
        public static OrderViewModel ToOrderViewModels(this Order orderDb)
        {
            var orderViewModels = new OrderViewModel()
            {
                Id = orderDb.Id,
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
        public static CompareViewModel ToCompareViewModel(this Compare compare)
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
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static FavoritesViewModel ToFavoritesViewModel(this Favorites favorite)
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
        public static List<OrderViewModel> ToOrdersViewModels(this List<Order> ordersDb)
        {
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var orderDb in ordersDb)
            {
                ordersViewModel.Add(ToOrderViewModels(orderDb));
            }
            return ordersViewModel;
        }
        public static List<OrderViewModel> ToOrdersViewModels(this IEnumerable<Order> orders)
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
            var userVM = new UserViewModel()
            {
                Login = new Login(),
                Orders = new List<OrderViewModel>(),
                Contacts = new UserContactViewModel(),
                Role = new RoleViewModel()
            };
            userVM.Id = userDb.Id;
            userVM.Contacts.Name = userDb.ContactsName ?? "";
            userVM.Contacts.Surname = userDb.Surname ?? "";
            userVM.Contacts.Adress = userDb.Adress ?? "";
            userVM.Contacts.Email = userDb.Email ?? "";
            userVM.Contacts.Phone = userDb.PhoneNumber ?? "";
            userVM.Image = userDb.Image ?? "/img/profile.webp";
            return userVM;
        }
        public static void AddUserContactToUserViewModel(this UserContact userDb, UserContactViewModel user)
        {
            user.Name = userDb.Name;
            user.Surname = userDb.Surname;
            user.Adress = userDb.Adress;
            user.Phone = userDb.Phone;
            user.Email = userDb.Email;
        }
        public static void AddUserContactDb(this UserContact userDb, UserContactViewModel user)
        {
            userDb.Name = user.Name;
            userDb.Surname = user.Surname;
            userDb.Adress = user.Adress;
            userDb.Phone = user.Phone;
            userDb.Email = user.Email;
        }
        public static List<UserViewModel> ToListUserViewModels(this IQueryable<User> usersDb)
        {
            var result = new List<UserViewModel>();
            foreach (var userDb in usersDb)
            {
                result.Add(userDb.ToUserViewModel());
            }
            return result;
        }
        public static void ChangeContactsUser(this User userDb, UserContactViewModel contacts)
        {
            userDb.ContactsName = contacts.Name;
            userDb.Surname = contacts.Surname;
            userDb.Adress = contacts.Adress;
            userDb.PhoneNumber = contacts.Phone;
            userDb.Email = contacts.Email;
        }
        public static List<RoleViewModel> ToListRoleViewModel(this IQueryable<IdentityRole> rolesDb)
        {
            var result = new List<RoleViewModel>();
            foreach (var roleDb in rolesDb)
            {
                result.Add(roleDb.ToRoleViewModel());
            }
            return result;
        }
        public static RoleViewModel ToRoleViewModel(this IdentityRole roleDb)
        {
            var role = new RoleViewModel();
            role.Id = roleDb.Id;
            role.Name = roleDb.Name ?? "Имя не указано";
            return role;
        }
        public static Product ToProduct(this AddProductViewModel addProductViewModel, List<string> imagesPaths)
        {
            return new Product()
            {
                Name = addProductViewModel.Name,
                Cost = addProductViewModel.Cost,
                Description = addProductViewModel.Description,
                Images = imagesPaths.ToImages()
            };
        }
        public static List<Image> ToImages(this List<string> paths)
        {
            return paths.Select(x => new Image { Url = x }).ToList();
        }
        public static Product ToProduct(this ProductViewModel product, List<string> imagesPaths)
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Images = imagesPaths.ToImages()
            };
        }
        public static Product ToProduct(this ProductViewModel editProduct)
        {
            return new Product
            {
                Id = editProduct.Id,
                Name = editProduct.Name,
                Cost = editProduct.Cost,
                Description = editProduct.Description,
                Images = editProduct.Images.ToImages()
            };
        }
    }
}
