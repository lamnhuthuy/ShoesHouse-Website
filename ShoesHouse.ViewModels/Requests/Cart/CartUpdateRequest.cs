﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.ViewModels.Requests.Cart
{
    public class CartUpdateRequest
    {
        public int IdProduct { get; set; }
        public int Amount { get; set; }
    }
}
