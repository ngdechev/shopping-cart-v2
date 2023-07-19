using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineShop.commands;

partial class Program
{
    static void Main(string[] args)
    {
        var shoppingCart = new ShoppingCart();
        var productList = new ProductList();

        Console.WriteLine("Welcome to the Shopping Cart App!");

        UserRole userRole = GetUserRole();

        var commands = new Dictionary<string, ICommand>
        {
            {"addProduct", new AddProductCommand()},
            {"removeProduct", new RemoveProductCommand()},
            {"editProduct", new EditProductCommand()},
            {"listProducts", new ListProductsCommand()},
            {"searchProducts", new SearchProductsCommand()},
            {"addCartItem", new AddCartItemCommand()},
            {"removeCartItem", new RemoveCartItemCommand()},
            {"updateCartItem", new UpdateCartItemCommand()},
            {"checkout", new CheckoutCommand()}
        };

        commands.Add("help", new HelpCommand(commands));
        commands.Add("exit", new ExitCommand());
        commands.Add("login", new LoginCommand(commands));

        if (userRole == UserRole.RestrictedUser)
        {
            commands = GetRestrictedCommands(commands);
        }

        RunCommandLoop(commands, productList, shoppingCart);

        // Save the product list to a file
        productList.SaveToFile("product_list.txt");
    }

    private static UserRole GetUserRole()
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
                    return UserRole.Administrator;
                }
                else if (roleChoice == 2)
                {
                    return UserRole.Customer;
                }
                else if (roleChoice == 3)
                {
                    return UserRole.RestrictedUser;
                }
            }
            Console.WriteLine("Invalid input. Please enter the number corresponding to the desired role.");
        }
    }

    private static Dictionary<string, ICommand> GetRestrictedCommands(Dictionary<string, ICommand> allCommands)
    {
        var restrictedCommands = new Dictionary<string, ICommand>
        {
            {"login", allCommands["login"]},
            {"help", allCommands["help"]},
            {"exit", allCommands["exit"]}
        };

        return restrictedCommands;
    }

    private static void RunCommandLoop(Dictionary<string, ICommand> commands, ProductList productList, ShoppingCart shoppingCart)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Enter a command (type 'help' for available commands):");
            string command = Console.ReadLine();

            string[] commandParts = command.Split("|").Select(part => part.Trim()).ToArray();
            string commandName = commandParts[0];

            if (commands.TryGetValue(commandName, out ICommand commandHandler))
            {
                commandHandler.Execute(commandParts, productList, shoppingCart);
            }
            else
            {
                Console.WriteLine("Invalid command. Type 'help' for available commands.");
            }
        }
    }
}