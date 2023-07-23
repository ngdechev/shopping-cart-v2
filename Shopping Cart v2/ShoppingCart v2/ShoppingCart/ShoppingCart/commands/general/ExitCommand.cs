using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineShop.classes.helpers;

namespace OnlineShop.commands
{
    class ExitCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            
        }

        public void SaveChangesAndExit(ProductList productList)
        {
            Console.WriteLine("Have a nice day!");
            productList.SaveToFile(Helpers.filePath);
            Environment.Exit(0);
        }

        public void Help()
        {
            Console.WriteLine("Usage: exit");
            Console.WriteLine("Description: Exits the application.");
        }
    }
}
