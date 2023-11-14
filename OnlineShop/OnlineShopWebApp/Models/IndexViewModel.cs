using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
