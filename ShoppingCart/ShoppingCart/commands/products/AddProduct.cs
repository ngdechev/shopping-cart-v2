using System.Windows.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.interfaces;

namespace OnlineShop.commands
{
    class AddProductCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 5)
            {
                int productId;
                string name = commandParts[1].Trim();
                string description = commandParts[2].Trim();
                int quantity = int.Parse(commandParts[3].Trim());
                decimal price = decimal.Parse(commandParts[4].Trim());

                var product = new Product(name, description, quantity, price);
                productId = product.Id++;
                productList.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid command format for adding a product.");
            }
        }

        public void Help()
        {
            Console.WriteLine("addProduct {name} | {description} | {quantity} | {price}");
            Console.WriteLine("\tAdds a new product to the list with the specified name, description, quantity, and price.");
        }
    }
}
