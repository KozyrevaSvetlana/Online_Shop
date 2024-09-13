﻿using System;
using System.Collections.Generic;

namespace ModelsLibrary.ModelsDto
{
    public class Compare
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; }

        public Compare()
        {
            Items = new List<Product>();
        }
    }
}