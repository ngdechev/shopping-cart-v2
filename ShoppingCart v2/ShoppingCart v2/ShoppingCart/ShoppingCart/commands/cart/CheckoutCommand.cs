using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class CheckoutCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            //shoppingCart.Checkout();
            Console.WriteLine("Thank you for your purchase!");
        }

        public void Help()
        {
            Console.WriteLine("Usage: checkout");
            Console.WriteLine("Description: Completes the purchase process and checks out the items in the shopping cart.");
        }
    }
}
