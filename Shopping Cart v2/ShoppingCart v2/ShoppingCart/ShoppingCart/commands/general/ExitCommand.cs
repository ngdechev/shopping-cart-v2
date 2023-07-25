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
            SaveChangesAndExit(productList);
            System.Environment.Exit(0);
        }

        public void SaveChangesAndExit(ProductList productList)
        {
            Console.WriteLine("Have a nice day!");
            productList.SaveToFile(Helpers.filePath);
        }

        public void Help()
        {
            Console.WriteLine("Usage: exit");
            Console.WriteLine("Description: Exits the application.");
        }
    }
}
