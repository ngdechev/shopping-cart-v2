using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class ExitCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            Console.WriteLine("Exiting the application...");
            productList.SaveToFile("product_list.txt");
            Environment.Exit(0);
        }

        public void Help()
        {
            Console.WriteLine("Usage: exit");
            Console.WriteLine("Description: Exits the application.");
        }
    }
}
