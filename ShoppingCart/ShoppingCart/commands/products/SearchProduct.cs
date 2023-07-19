using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.classes.wrapper_classes;
using OnlineShop.interfaces;

namespace OnlineShop.commands.products
{
    class SearchProductsCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 2)
            {
                string searchTerm = commandParts[1].Trim();
                productList.SearchProducts(searchTerm);
            }
            else
            {
                Console.WriteLine("Invalid command format for searching products.");
            }
        }

        public void Help()
        {
            Console.WriteLine("searchProducts {searchTerm}");
            Console.WriteLine("\tSearches for products matching the specified searchTerm in their name or description.");
        }
    }
}
