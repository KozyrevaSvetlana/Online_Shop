using System;
using System.Collections.Generic;

namespace Models.ModelsDto
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }

        public Image()
        {
            Products = new List<Product>();
        }
    }
}
