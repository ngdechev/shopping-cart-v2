using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    class CheckoutCommand : ICommand
    {
        public void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart)
        {
                if (commandParts.Length == 1)
                {
                if (shoppingCart.IsEmpty())
                {
                    Console.WriteLine("Shopping cart is empty. Add items before checking out.");
                    return;
                }

                decimal totalPrice = CalculateTotalPrice(shoppingCart, productList);
                Console.WriteLine($"Total Price: {totalPrice}");

                if (ConfirmCheckout())
                {
                    PerformCheckout(shoppingCart, productList);
                    Console.WriteLine("Checkout successful. Your order has been placed.");
                }
                else
                {
                    Console.WriteLine("Checkout canceled. Your cart items are preserved.");
                }
            } else
            {
                Console.WriteLine("Invalid command format for checkout.");
                Help();
            }

        }

        private decimal CalculateTotalPrice(ShoppingCart shoppingCart, ProductList productList)
        {
            decimal totalPrice = 0;

            foreach (var cartItem in shoppingCart.GetCartItems())
            {
                Product product = productList.GetProductById(cartItem.ProductId);
                if (product != null)
                {
                    totalPrice += product.Price * cartItem.Quantity;
                }
            }

            return totalPrice;
        }

        private bool ConfirmCheckout()
        {
            Console.Write("Confirm checkout (yes/no): ");
            string input = Console.ReadLine().Trim().ToLower();
            return input == "yes" || input == "y";
        }

        private void PerformCheckout(ShoppingCart shoppingCart, ProductList productList)
        {
            var cartItemsCopy = shoppingCart.GetCartItems().ToList();

            foreach (var cartItem in cartItemsCopy)
            {
                Product product = productList.GetProductById(cartItem.ProductId);
                if (product != null)
                {
                    product.Quantity -= cartItem.Quantity;
                    shoppingCart.RemoveCartItem(cartItem.Id);
                }
            }
        }

        public void Help()
        {
            Console.WriteLine("Usage: checkout");
            Console.WriteLine("Description: Completes the purchase process and checks out the items in the shopping cart.");
        }
    }
}
