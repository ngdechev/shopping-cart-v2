using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class LoginCommand : ICommand
    {
        private readonly Dictionary<string, ICommand> commands;

        public LoginCommand(Dictionary<string, ICommand> commands)
        {
            this.commands = commands;
        }

        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            Console.WriteLine("Please select a user role:");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Restricted User");

            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int roleChoice))
                {
                    if (roleChoice == 1)
                    {
                        Console.WriteLine("Logged in as Administrator.");
                        RunCommandLoop(commands);
                        break;
                    }
                    else if (roleChoice == 2)
                    {
                        Console.WriteLine("Logged in as Customer.");
                        RunCommandLoop(commands);
                        break;
                    }
                    else if (roleChoice == 3)
                    {
                        Console.WriteLine("Logged in as Restricted User.");
                        RunCommandLoop(GetRestrictedCommands(commands));
                        break;
                    }
                }
                Console.WriteLine("Invalid input. Please enter the number corresponding to the desired role.");
            }
        }

        public void Help()
        {
            Console.WriteLine("login");
            Console.WriteLine("\tLogs in the user with the specified role.");
        }

        private void RunCommandLoop(Dictionary<string, ICommand> availableCommands)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter a command (type 'help' for available commands):");
                string command = Console.ReadLine();

                string[] commandParts = command.Split('|');
                string commandName = commandParts[0].Trim().ToLower();

                if (availableCommands.TryGetValue(commandName, out ICommand commandHandler))
                {
                    commandHandler.Execute(commandParts, null, null);
                }
                else if (commandName == "exit")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid command. Type 'help' for available commands.");
                }
            }
        }

        private Dictionary<string, ICommand> GetRestrictedCommands(Dictionary<string, ICommand> allCommands)
        {
            var restrictedCommands = new Dictionary<string, ICommand>
            {
                {"login", this},
                {"help", allCommands["help"]},
                {"exit", allCommands["exit"]}
            };

            return restrictedCommands;
        }
    }

}
