using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands.cart
{
    class ListCartItemsCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            shoppingCart.DisplayCartItems(productList);
        }

        public void Help()
        {
            Console.WriteLine("Usage: listCartItems");
            Console.WriteLine("Description: Displays the items in the shopping cart.");
        }
    }

}
