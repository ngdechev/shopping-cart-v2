using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.classes.wrapper_classes;
using OnlineShop.interfaces;

namespace OnlineShop.commands.cart_items
{
    class CheckoutCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            shoppingCart.Checkout();
            Console.WriteLine("Thank you for your purchase!");
        }

        public void Help()
        {
            Console.WriteLine("checkout");
            Console.WriteLine("\tCompletes the purchase process and checks out the items in the shopping cart.");
        }
    }
}
