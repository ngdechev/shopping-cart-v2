using OnlineShop.classes.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class HelpCommand : ICommand
    {
        private readonly Dictionary<string, ICommand> commands;
        //UserRole userRole = Helpers.GetUserRole();

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
                    if (Helpers.IsCommandAccessible(command.Key, Helpers.GetUserRole()))
                    {
                        Console.WriteLine($"Command name: {command.Key}");
                        command.Value.Help();
                        Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    }
                }

            }
            else if (commandParts.Length == 2)
            {
                string commandName = commandParts[1].Trim();

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
                Console.WriteLine("Invalid command format for help.\n");
                Help();
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: help | {command}");
            Console.WriteLine("Description: Displays the list of available commands or provides help for a specific command.");
        }
    }
}
