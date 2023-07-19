﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.classes.entity
{
    class Product
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string description, int quantity, decimal price)
        {
            Id++;
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
