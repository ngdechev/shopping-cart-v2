using OnlineShop.classes.helpers;
using OnlineShop.commands;
using System;

namespace OnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize necessary objects
            var shoppingCart = new ShoppingCart();
            var productList = new ProductList();

            // Get the user role using the UserInputHandler class
            UserRole userRole = UserInputHandler.GetUserRole();

            // Initialize commands based on the user role
            var commands = Helpers.InitializeCommands(productList, shoppingCart, userRole);

            // Run the command loop
            Helpers.RunCommandLoop(commands, productList, shoppingCart, userRole);

            // Save the product list before exiting (optional)
            productList.SaveToFile("product_list.json");
        }
    }
}
