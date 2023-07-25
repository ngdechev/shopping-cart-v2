using OnlineShop.enums;
using System;

public class UserInputHandler
{
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

    public static UserRole GetUserRole()
    {
        return userRole;
    }
}

