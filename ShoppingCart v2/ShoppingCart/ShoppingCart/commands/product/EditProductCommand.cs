using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class EditProductCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 6)
            {
                int productId = int.Parse(commandParts[1].Trim());
                string name = commandParts[2].Trim();
                string description = commandParts[3].Trim();
                int quantity = int.Parse(commandParts[4].Trim());
                decimal price = decimal.Parse(commandParts[5].Trim());

                if (productList.EditProduct(productId, name, description, quantity, price))
                {
                    Console.WriteLine("Product edited successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for editing a product.");
            }
        }

        public void Help()
        {
            Console.WriteLine("editProduct {productId} | {name} | {description} | {quantity} | {price}");
            Console.WriteLine("\tEdits the product with the specified productId and updates its name, description, quantity, and price.");
        }
    }
}
