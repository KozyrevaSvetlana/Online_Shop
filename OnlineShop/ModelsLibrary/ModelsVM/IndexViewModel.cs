using System.Collections.Generic;

namespace ModelsLibrary.ModelsVM
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
