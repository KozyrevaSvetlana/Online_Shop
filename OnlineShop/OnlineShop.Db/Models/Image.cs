﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
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
