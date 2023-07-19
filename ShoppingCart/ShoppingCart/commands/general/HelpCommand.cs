using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.classes.wrapper_classes;
using OnlineShop.interfaces;

namespace OnlineShop.commands.general
{
    class HelpCommand : ICommand
    {
        private readonly Dictionary<string, ICommand> commands;

        public HelpCommand(Dictionary<string, ICommand> commands)
        {
            this.commands = commands;
        }

        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 1)
            {
                Console.WriteLine("Available commands:");

                foreach (var command in commands)
                {
                    Console.WriteLine(command.Key);
                }
            }
            else if (commandParts.Length == 2)
            {
                string commandName = commandParts[1].Trim().ToLower();

                if (commands.TryGetValue(commandName, out ICommand command))
                {
                    command.Help();
                }
                else
                {
                    Console.WriteLine("Command not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format for help.");
            }
        }

        public void Help()
        {
            Console.WriteLine("help [command]");
            Console.WriteLine("\tDisplays the list of available commands or provides help for a specific command.");
        }
    }
}
