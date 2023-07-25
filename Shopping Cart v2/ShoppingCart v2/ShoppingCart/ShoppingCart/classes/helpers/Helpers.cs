using OnlineShop.commands.cart;
using OnlineShop.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using OnlineShop.enums;

namespace OnlineShop.classes.helpers
{
    static class Helpers
    {
        public static string filePath = "product_list.json";

        public static Dictionary<string, ICommand> InitializeCommands(ProductList productList, ShoppingCart shoppingCart, UserRole userRole)
        {
            var generalCommands = GeneralCommands();

            if (userRole == UserRole.Administrator)
            {
                AddAdministratorCommands(generalCommands);
            }
            else if (userRole == UserRole.Customer)
            {
                AddCustomerCommands(generalCommands);
            }

            generalCommands["help"] = new HelpCommand(generalCommands);

            return generalCommands;
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
            commands.Add("listCartItems", new ListCartItemsCommand());
            commands.Add("checkout", new CheckoutCommand());
        }

        private static void AddCustomerCommands(Dictionary<string, ICommand> commands)
        {
            commands.Add("addCartItem", new AddCartItemCommand());
            commands.Add("removeCartItem", new RemoveCartItemCommand());
            commands.Add("updateCartItem", new UpdateCartItemCommand());
            commands.Add("searchProducts", new SearchProductsCommand());
            commands.Add("listCartItem", new ListCartItemsCommand());
            commands.Add("checkout", new CheckoutCommand());
        }

        private static Dictionary<string, ICommand> GeneralCommands() {
            var commands = new Dictionary<string, ICommand>
            {
                {"help", new HelpCommand(null)},
                {"exit", new ExitCommand()},
                {"login", new LoginCommand(null, UserInputHandler.GetUserRole())}
            };

            return commands;
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
                    "searchProducts" => true,
                    "listCartItem" => true,
                    "checkout" => true,
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
