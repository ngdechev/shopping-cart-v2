using OnlineShop.commands.cart;
using OnlineShop.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OnlineShop.classes.helpers
{
    static class Helpers
    {
        public static string filePath = "product_list.json";
        private static UserRole userRole;

        public static UserRole MainScreen()
        {
            Console.WriteLine("Welcome to the Shopping Cart App!");
            Console.WriteLine("Available Commands:");
            Console.WriteLine("login - Log in with a user role");
            Console.WriteLine("help - Show available commands");
            Console.WriteLine("exit - Exit the application");

            while (true)
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "login")
                {   
                    // Ask the user to select a user role
                    Console.WriteLine("Please select a user role:");
                    Console.WriteLine("1. Administrator");
                    Console.WriteLine("2. Customer");

                    while (true)
                    {
                        string roleChoice = Console.ReadLine();
                        if (int.TryParse(roleChoice, out int roleNumber) && Enum.IsDefined(typeof(UserRole), roleNumber - 1))
                        {
                            userRole = (UserRole)(roleNumber - 1);
                        }
                        Console.WriteLine("Invalid input. Please enter the number corresponding to the desired role.");
                    }
                }
                else if (userInput == "help")
                {
                    Console.WriteLine("Available Commands:");
                    Console.WriteLine("1. login - Log in with a user role");
                    Console.WriteLine("2. help - Show available commands");
                    Console.WriteLine("3. exit - Exit the application");
                }
                else if (userInput == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command. Type 'help' for available commands.");
                }
            }
        }

        public static UserRole GetUserRole()
        {
            return userRole;
        }

        public static Dictionary<string, ICommand> InitializeCommands(ProductList productList, ShoppingCart shoppingCart, UserRole userRole)
        {
            var commands = new Dictionary<string, ICommand>
            {
                {"help", new HelpCommand(null)},
                {"exit", new ExitCommand()},
                {"login", new LoginCommand(null, userRole)}
            };

            if (userRole == UserRole.Administrator)
            {
                AddAdministratorCommands(commands);
            }
            else if (userRole == UserRole.Customer)
            {
                AddCustomerCommands(commands);
            }

            commands["help"] = new HelpCommand(commands);

            return commands;
        }

        private static void AddAdministratorCommands(Dictionary<string, ICommand> commands)
        {
            commands.Add("addProduct", new AddProductCommand());
            commands.Add("removeProduct", new RemoveProductCommand());
            commands.Add("editProduct", new EditProductCommand());
            commands.Add("listProducts", new ListProductsCommand());
            commands.Add("searchProducts", new SearchProductsCommand());
            commands.Add("addCartItem", new AddCartItemCommand());
            commands.Add("removeCartItem", new RemoveCartItemCommand());
            commands.Add("updateCartItem", new UpdateCartItemCommand());
        }

        private static void AddCustomerCommands(Dictionary<string, ICommand> commands)
        {
            commands.Add("listCartItems", new ListCartItems());
            commands.Add("checkout", new CheckoutCommand());
            commands.Add("searchProducts", new SearchProductsCommand());
            commands.Add("addCartItem", new AddCartItemCommand());
            commands.Add("removeCartItem", new RemoveCartItemCommand());
            commands.Add("updateCartItem", new UpdateCartItemCommand());
        }

        public static void RunCommandLoop(Dictionary<string, ICommand> commands, ProductList productList, ShoppingCart shoppingCart, UserRole userRole)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nEnter a command (type 'help' for available commands):");
                string command = Console.ReadLine();

                string[] commandParts = command.Split('|').Select(part => part.Trim()).ToArray();
                string commandName = commandParts[0];

                if (commands.TryGetValue(commandName, out ICommand commandHandler))
                {
                    if (IsCommandAccessible(commandName, userRole))
                    {
                        commandHandler.Execute(commandParts, productList, shoppingCart);
                    }
                    else
                    {
                        Console.WriteLine("You don't have access to this command.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid command. Type 'help' for available commands.");
                }
            }
        }

        public static bool IsCommandAccessible(string commandName, UserRole userRole)
        {
            if (userRole == UserRole.Administrator)
            {
                return true;
            }
            else if (userRole == UserRole.Customer)
            {
                return commandName switch
                {
                    "addCartItem" => true,
                    "removeCartItem" => true,
                    "updateCartItem" => true,
                    "help" => true,
                    "listcartitems" => true,
                    "checkout" => true,
                    "exit" => true,
                    "login" => true,
                    _ => false,
                };
            }
            else
            {
                return commandName switch
                {
                    "help" => true,
                    "login" => true,
                    "exit" => true,
                    _ => false,
                };
            }
        }
    }
}
