using OnlineShop.commands;
using OnlineShop.commands.cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.classes.helpers
{
    static class Helpers
    {
        public static UserRole GetUserRole()
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
                            return (UserRole)(roleNumber - 1);
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


        public static Dictionary<string, ICommand> GetRestrictedCommands(Dictionary<string, ICommand> allCommands)
        {
            var restrictedCommands = new Dictionary<string, ICommand>
        {
            {"login", allCommands["login"]},
            {"help", allCommands["help"]},
            {"exit", allCommands["exit"]}
        };

            return restrictedCommands;
        }

        public static void RunCommandLoop(Dictionary<string, ICommand> commands, ProductList productList, ShoppingCart shoppingCart, UserRole userRole)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter a command (type 'help' for available commands):");
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
                    Console.WriteLine("Invalid command. Type 'help' for available commands.");
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

        public static void AddCommands()
        {
            var shoppingCart = new ShoppingCart();
            var productList = new ProductList();

            /*List<Product> prod_list = productList.LoadFromFile("product_list.json");

            foreach(Product product in prod_list)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }*/

            UserRole userRole = Helpers.GetUserRole();

            var commands = new Dictionary<string, ICommand>
            {
                {"help", new HelpCommand(null)},
                {"exit", new ExitCommand()},
                {"login", new LoginCommand(null, userRole)}
            };

            if (userRole == UserRole.Administrator)
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

            if (userRole == UserRole.Customer)
            {
                commands.Add("listCartItems", new ListCartItems());
                commands.Add("checkout", new CheckoutCommand());
                commands.Add("searchProducts", new SearchProductsCommand());
                commands.Add("addCartItem", new AddCartItemCommand());
                commands.Add("removeCartItem", new RemoveCartItemCommand());
                commands.Add("updateCartItem", new UpdateCartItemCommand());
            }

            commands["help"] = new HelpCommand(commands);

            //commands["login"].Execute(null, productList, shoppingCart);

            Helpers.RunCommandLoop(commands, productList, shoppingCart, userRole);

            productList.SaveToFile("product_list.json");
        }
    }
}
