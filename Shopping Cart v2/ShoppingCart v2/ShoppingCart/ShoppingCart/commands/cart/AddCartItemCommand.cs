using OnlineShop.classes.helpers;
using OnlineShop.commands.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{

    class AddCartItemCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 3)
            {
                int productId = int.Parse(commandParts[1].Trim());
                int quantity = int.Parse(commandParts[2].Trim());

                Product product = productList.GetProductById(productId);

                if (shoppingCart.AddCartItem(productList, productId, quantity))
                {
                    Console.WriteLine($"Product {product.Name} added to the cart successfully!");
                    Logger1.Debug(UserInputHandler.GetUserRole(), $"Product {product.Name} added to the cart successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found or insufficient quantity available.");
                    Logger1.Warn(UserInputHandler.GetUserRole(), "Product not found or insufficient quantity available.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for adding a cart item.\n");
                Help();
                Logger1.Error(UserInputHandler.GetUserRole(), "Invalid command format for adding a cart item.");
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: addCartItem | {productId} | {quantity}");
            Console.WriteLine("Description: Adds the specified quantity of the product with the given productId to the shopping cart.");
        }
    }
}
