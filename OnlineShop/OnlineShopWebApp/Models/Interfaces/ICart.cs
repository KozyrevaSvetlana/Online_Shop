﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models.Interfaces
{
    public interface ICart
    {
        IEnumerable<Cart> AllCarts { get; }
    }
}
