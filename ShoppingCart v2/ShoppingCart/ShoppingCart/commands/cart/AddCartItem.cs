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

                if (shoppingCart.AddCartItem(productList, productId, quantity))
                {
                    Console.WriteLine("Item added to the cart successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found or insufficient quantity available.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for adding a cart item.");
            }
        }

        public void Help()
        {
            Console.WriteLine("addCartItem {productId} | {quantity}");
            Console.WriteLine("\tAdds the specified quantity of the product with the given productId to the shopping cart.");
        }
    }
}
