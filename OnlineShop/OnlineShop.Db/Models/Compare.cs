using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Compare
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<Guid> Items { get; set; }

        public Compare()
        {
            Items = new List<Guid>();
        }
    }
}
