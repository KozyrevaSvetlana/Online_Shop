using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class InfoStatusOrderViewModel
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
        public InfoStatusOrderViewModel(DateTime dateTime)
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
        public void ChangeStatus(string newstatus)
        {
            switch (newstatus)
            {
                case "Создан":
                    StatusOrder = Status.Created;
                    break;
                case "В работе":
                    StatusOrder = Status.InProcessing;
                    break;
                case "В пути":
                    StatusOrder = Status.Delivering;
                    break;
                case "Готов к выдаче":
                    StatusOrder = Status.OnPost;
                    break;
                case "Выполнен":
                    StatusOrder = Status.Done;
                    break;
            }
        }
        public List<string> GetAllStatuses()
        {
            var result = new List<string>() { "Создан", "В работе", "В пути", "Готов к выдаче", "Выполнен" };
            return result;
        }
    }
}