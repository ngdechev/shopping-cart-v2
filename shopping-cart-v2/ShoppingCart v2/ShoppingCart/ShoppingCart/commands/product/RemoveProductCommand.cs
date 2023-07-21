using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class RemoveProductCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 2)
            {
                int productId = int.Parse(commandParts[1].Trim());

                if (productList.RemoveProduct(productId))
                {
                    Console.WriteLine("Product removed successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for removing a product.");
            }
        }

        public void Help()
        {
            Console.WriteLine("removeProduct | {productId}");
            Console.WriteLine("\tRemoves the product with the specified productId from the list.");
        }
    }

}
