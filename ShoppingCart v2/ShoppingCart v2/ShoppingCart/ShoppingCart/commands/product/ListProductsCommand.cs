using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class ListProductsCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            productList.DisplayProductList();
        }

        public void Help()
        {
            Console.WriteLine("Usage: listProducts");
            Console.WriteLine("Description: Displays the list of available products.");
        }
    }
}
