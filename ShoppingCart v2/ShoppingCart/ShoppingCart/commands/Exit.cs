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
            Environment.Exit(0);
        }

        public void Help()
        {
            Console.WriteLine("exit");
            Console.WriteLine("\tExits the application.");
        }
    }
}
