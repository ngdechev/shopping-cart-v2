using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string description, int quantity, decimal price)
        {
            Name = name;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
