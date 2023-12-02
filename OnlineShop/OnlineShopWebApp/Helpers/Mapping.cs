using Microsoft.AspNetCore.Identity;
using ModelsLibrary.ModelsDto;
using Nelibur.ObjectMapper;
using ModelsLibrary.ModelsVM;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static ModelsLibrary.ModelsVM.InfoStatusOrderViewModel;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
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
                Items = cart.Items.Select(TinyMapper.Map<CartItemViewModel>).ToList()
            };
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
            orderViewModels.Products = orderDb.Items.Select(TinyMapper.Map<CartItemViewModel>).ToList();
            return orderViewModels;
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
            userVM.Login.Email = userDb.UserName;
            return userVM;
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
                result.Add(TinyMapper.Map<RoleViewModel>(roleDb));
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
    }
}
