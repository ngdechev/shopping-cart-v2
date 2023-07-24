using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.enums;

namespace OnlineShop.commands
{
    class LoginCommand : ICommand
    {
        private readonly Dictionary<string, ICommand> commands;
        private UserRole userRole;

        public LoginCommand(Dictionary<string, ICommand> commands, UserRole userRole)
        {
            this.commands = commands;
            this.userRole = userRole;
        }

        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            Console.WriteLine("Logged in as " + userRole + ".");
        }

        public void Help()
        {
            Console.WriteLine("Usage: login");
            Console.WriteLine("Description: Logs in the user with the specified role.");
        }
    }

}