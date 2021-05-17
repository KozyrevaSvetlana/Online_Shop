using System;

namespace OnlineShopWebApp.Models
{
    public class InfoStatusOrder
    {
        public Status StatusOrder { get; set; }
        public DateTime Data { get; set; }
        public enum Status
        {
            Created,
            InProcessing,
            Delivering,
            OnPost,
            Done
        }
        public InfoStatusOrder(DateTime dateTime)
        {
            StatusOrder = Status.Created;
            Data = dateTime;
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