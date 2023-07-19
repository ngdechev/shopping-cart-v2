using OnlineShop.commands;
using OnlineShop.commands.cart;

partial class Program
{
    static void Main(string[] args)
    {
        var shoppingCart = new ShoppingCart();
        var productList = new ProductList();

        // Load the product list from a file
        productList.LoadFromFile("product_list.txt");

        UserRole userRole = GetUserRole();

        var commands = new Dictionary<string, ICommand>
    {
        {"help", new HelpCommand(null)},
        {"exit", new ExitCommand()},
        {"login", new LoginCommand(null, userRole)}
    };

        if (userRole == UserRole.Administrator)
        {
            // Add commands for the Administrator
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
            // Add commands for the Customer
            commands.Add("listCartItems", new ListCartItems());
            commands.Add("checkout", new CheckoutCommand());
            commands.Add("searchProducts", new SearchProductsCommand());
            commands.Add("addCartItem", new AddCartItemCommand());
            commands.Add("removeCartItem", new RemoveCartItemCommand());
            commands.Add("updateCartItem", new UpdateCartItemCommand());
        }

        // Update the HelpCommand with the commands dictionary
        commands["help"] = new HelpCommand(commands);

        // Execute the login command to display the welcome message with available commands
        commands["login"].Execute(null, productList, shoppingCart);

        // Run the command loop after the user logs in
        RunCommandLoop(commands, productList, shoppingCart, userRole);

        // Save the product list to a file
        productList.SaveToFile("product_list.txt");
    }



    private static UserRole GetUserRole()
    {
        Console.WriteLine("Welcome to the Shopping Cart App!");
        Console.WriteLine("Available Commands:");
        Console.WriteLine("1. login - Log in with a user role");
        Console.WriteLine("2. help - Show available commands");
        Console.WriteLine("3. exit - Exit the application");

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
                // Show available commands again
                Console.WriteLine("Available Commands:");
                Console.WriteLine("1. login - Log in with a user role");
                Console.WriteLine("2. help - Show available commands");
                Console.WriteLine("3. exit - Exit the application");
            }
            else if (userInput == "exit")
            {
                // Exit the application
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid command. Type 'help' for available commands.");
            }
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

    private static void RunCommandLoop(Dictionary<string, ICommand> commands, ProductList productList, ShoppingCart shoppingCart, UserRole userRole)
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


    private static bool IsCommandAccessible(string commandName, UserRole userRole)
    {
        if (userRole == UserRole.Administrator)
        {
            // All commands are accessible to the Administrator
            return true;
        }
        else if (userRole == UserRole.Customer)
        {
            // Allow only certain commands for the Customer
            return commandName switch
            {
                "help" => true,
                "listcartitems" => true,
                "checkout" => true,
                "exit" => true,
                _ => false,
            };
        }
        else
        {
            // Restricted User has access to help, login, and exit only
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