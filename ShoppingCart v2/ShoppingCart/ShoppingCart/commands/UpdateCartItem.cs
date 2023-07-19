using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class UpdateCartItemCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 3)
            {
                int cartItemId = int.Parse(commandParts[1].Trim());
                int newQuantity = int.Parse(commandParts[2].Trim());

                if (shoppingCart.UpdateCartItem(cartItemId, newQuantity))
                {
                    Console.WriteLine("Cart item updated successfully!");
                }
                else
                {
                    Console.WriteLine("Item not found in the cart.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for updating a cart item.");
            }
        }

        public void Help()
        {
            Console.WriteLine("updateCartItem {cartItemId} | {newQuantity}");
            Console.WriteLine("\tUpdates the quantity of the cart item with the specified cartItemId to the newQuantity.");
        }
    }

}
