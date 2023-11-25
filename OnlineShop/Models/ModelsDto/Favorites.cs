using System;
using System.Collections.Generic;

namespace Models.ModelsDto
{
    public class Favorites
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; }

        public Favorites()
        {
            Items = new List<Product>();
        }
    }
}
