using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public partial class Order
    {
        private static int count = 0;
        public int Number { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Products { get; set; }
        public UserContact User { get; set; }
        public Status StatusOrder { get; set; }
        public enum Status
        {
            Created,
            InProcessing,
            Delivering,
            OnPost,
            Done
        }

        public void AddContacts(string userId, UserContact user)
        {
            count++;
            Number = count;
            UserId = userId;
            User = user;
            StatusOrder = Status.Created;
        }

        public decimal Cost
        {
            get
            {
                return Products?.Sum(x => x.Cost) ?? 0;
            }
        }
        public string GetStatus(Status StatusOrder)
        {
            switch (StatusOrder)
            {
                case Status.Created:
                    return "Создан";
                case Status.InProcessing:
                    return "В работе";
                case Status.Delivering:
                    return "В пути";
                case Status.OnPost:
                    return "Готов к выдаче";
                case Status.Done:
                    return "Выполнен";
                default:
                    return "Ошибка";
            }
        }
    }
}
