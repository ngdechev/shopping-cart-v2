using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class RemoveCartItemCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 2)
            {
                int cartItemId = int.Parse(commandParts[1].Trim());

                if (shoppingCart.RemoveCartItem(cartItemId))
                {
                    Console.WriteLine("Item removed from the cart successfully!");
                }
                else
                {
                    Console.WriteLine("Item not found in the cart.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for removing a cart item.");
            }
        }

        public void Help()
        {
            Console.WriteLine("removeCartItem | {cartItemId}");
            Console.WriteLine("\tRemoves the cart item with the specified cartItemId from the shopping cart.");
        }
    }
}
