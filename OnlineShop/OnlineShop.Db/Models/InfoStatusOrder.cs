using System;

namespace OnlineShop.Db.Models
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
    }
}