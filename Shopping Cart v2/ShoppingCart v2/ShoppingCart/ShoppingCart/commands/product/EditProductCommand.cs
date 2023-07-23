using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class EditProductCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
            if (commandParts.Length == 4)
            {
                if (!int.TryParse(commandParts[1].Trim(), out int productId))
                {
                    Console.WriteLine("Invalid product ID. Please enter a valid number.");
                    return;
                }

                Product productToEdit = productList.GetProductById(productId);
                if (productToEdit == null)
                {
                    Console.WriteLine($"Product with ID {productId} not found.");
                    return;
                }

                string chosenPart = commandParts[2].Trim().ToLower();
                string newValue = commandParts[3].Trim();

                string oldName = productToEdit.Name;
                string oldDescription = productToEdit.Description;
                int oldQuantity = productToEdit.Quantity;
                decimal oldPrice = productToEdit.Price;

                switch (chosenPart)
                {
                    case "name":
                        if (chosenPart == "name" && string.IsNullOrWhiteSpace(newValue))
                        {
                            Console.WriteLine("Invalid name. Name cannot be empty or whitespace.");
                            return;
                        }
                        productToEdit.Name = newValue;
                        break;
                    case "description":
                        if (chosenPart == "description" && string.IsNullOrWhiteSpace(newValue))
                        {
                            Console.WriteLine("Invalid description. Description cannot be empty or whitespace.");
                            return;
                        }
                        productToEdit.Description = newValue;
                        break;
                    case "quantity":
                        if (!int.TryParse(newValue, out int newQuantity) || newQuantity < 0)
                        {
                            Console.WriteLine("Invalid quantity value. Please enter a non-negative integer.");
                            return;
                        }
                        productToEdit.Quantity = newQuantity;
                        break;
                    case "price":
                        if (!decimal.TryParse(newValue, out decimal newPrice) || newPrice < 0)
                        {
                            Console.WriteLine("Invalid price value. Please enter a non-negative decimal.");
                            return;
                        }
                        productToEdit.Price = newPrice;
                        break;
                    default:
                        Console.WriteLine("Invalid part chosen for edit. Available options: name, description, quantity, price");
                        break;
                }

                Console.WriteLine("Product edited successfully.");
                Console.WriteLine($"Old product details:\nName: {oldName}, Description: {oldDescription}, Quantity: {oldQuantity}, Price: {oldPrice}");
                Console.WriteLine("New product details:");
                Console.WriteLine($"Name: {productToEdit.Name}, Description: {productToEdit.Description}, Quantity: {productToEdit.Quantity}, Price: {productToEdit.Price}");
            }
            else
            {
                Console.WriteLine("Invalid command format for edditing a product.\n");
                Help();
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: editProduct | {productId} | {field} | {newFieldValue}");
            Console.WriteLine("Description: Edits the product with the specified productId and updates its name, description, quantity, and price.");
        }
    }
}
