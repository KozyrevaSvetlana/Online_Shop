using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public Login Login { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public UserContactViewModel Contacts { get; set; }
        public RoleViewModel Role { get; set; }
        public string Image { get; set; }
        public UserViewModel() { }
        public void AddContacts(UserContactViewModel contacts)
        {
            Contacts.Name = contacts.Name;
            Contacts.Surname = contacts.Surname;
            Contacts.Email = contacts.Email;
            Contacts.Phone = contacts.Phone;
            Contacts.Adress = contacts.Adress;
        }
        public List<string> GetEmptyContacts()
        {
            var result = new List<string>();
            if (Contacts.Name == "")
            {
                result.Add("Имя не заполнено");
            }
            if (Contacts.Surname == "")
            {
                result.Add("Фамилия не заполнена");
            }
            if (Contacts.Adress == "")
            {
                result.Add("Адрес не заполнен");
            }
            if (Contacts.Phone == "")
            {
                result.Add("Телефон не заполнен");
            }
            if (Contacts.Email == "")
            {
                result.Add("Email не заполнен");
            }
            return result;
        }
    }
}
