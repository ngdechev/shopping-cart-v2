using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class UpdateProductQuantityCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 3)
            {
                int productId = int.Parse(commandParts[1].Trim());
                int newQuantity = int.Parse(commandParts[2].Trim());

                if (shoppingCart.UpdateProductQuantity(productList, productId, newQuantity))
                {

                    Console.WriteLine("Product quantity updated successfully!");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for updating the product quantity.\n");
                Help();
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: updateProductQuantity | {productId} | {newQuantity}");
            Console.WriteLine("Description: Updates the quantity of the cart item with the specified cartItemId to the newQuantity.");
        }
    }

}

