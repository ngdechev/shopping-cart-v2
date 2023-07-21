using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
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
                Console.WriteLine("Invalid command format for searching products.\n");
                Help();
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: searchProducts | {searchTerm}");
            Console.WriteLine("Description: Searches for products matching the specified searchTerm in their name or description.");
        }
    }
}
