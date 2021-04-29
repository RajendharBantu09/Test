﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Products
    {
        public long ID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Quantity { get; set; }

    }
}