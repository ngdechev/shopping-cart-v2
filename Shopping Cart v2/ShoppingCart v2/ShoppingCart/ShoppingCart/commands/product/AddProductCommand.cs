using System.Windows.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class AddProductCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 5)
            {
                string name = commandParts[1];
                string description = commandParts[2];

                if (!int.TryParse(commandParts[3], out int quantity) || !decimal.TryParse(commandParts[4], out decimal price))
                {
                    Console.WriteLine("Invalid quantity or price format. Quantity must be an integer, and price must be a decimal number.");
                    return;
                }

                Product newProduct = new Product(name, description, quantity, price);
                productList.AddProduct(newProduct);
                Console.WriteLine($"Product '{name}' has been added.");                
            }
            else
            {
                Console.WriteLine("Invalid command format for adding a product.\n");
                Help();
            }

        }

        public void Help()
        {
            Console.WriteLine("Usage: addProduct | {name} | {description} | {quantity} | {price}");
            Console.WriteLine("Description: Adds a new product to the product list.");
        }
    }

}
