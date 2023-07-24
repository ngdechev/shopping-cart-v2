using OnlineShop.classes.helpers;
using OnlineShop.commands;
using OnlineShop.enums;
using System;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppingCart = new ShoppingCart();
            var productList = new ProductList();
            ExitCommand exitCommand = new();
            UserRole userRole = UserInputHandler.GetUserRole();
            var commands = Helpers.InitializeCommands(productList, shoppingCart, userRole);

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                Console.WriteLine("Ctrl+C detected.");
                exitCommand.SaveChangesAndExit(productList);
            };

            Helpers.RunCommandLoop(commands, productList, shoppingCart, userRole);
        }
    }
}
