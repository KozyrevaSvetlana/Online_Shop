namespace OnlineShop.Db.Models
{
    public partial class InfoStatusOrder
    {
        public enum Status
        {
            Created,
            InProcessing,
            Delivering,
            OnPost,
            Done
        }
    }
}