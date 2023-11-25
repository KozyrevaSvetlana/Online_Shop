using System;

namespace ModelsLibrary.ModelsDto
{
    public  class ProductsImages
    {
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
