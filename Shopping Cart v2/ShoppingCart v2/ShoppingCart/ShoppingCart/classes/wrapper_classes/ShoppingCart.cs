using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineShop.commands
{
    class ShoppingCart
    {
        private List<CartItem> cartItems;

        public ShoppingCart()
        {
            cartItems = new List<CartItem>();
        }

        public bool AddCartItem(ProductList productList, int productId, int quantity)
        {
            Product product = productList.GetProductById(productId);
            if (product != null && product.Quantity >= quantity)
            {
                cartItems.Add(new CartItem(productId, quantity));
                return true;
            }
            return false;
        }

        public bool RemoveCartItem(int cartItemId)
        {
            CartItem cartItem = cartItems.Find(item => item.Id == cartItemId);
            if (cartItem != null)
            {
                cartItems.Remove(cartItem);
                return true;
            }
            return false;
        }

        public bool UpdateCartItem(int cartItemId, int newQuantity)
        {
            CartItem cartItem = cartItems.Find(item => item.Id == cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity;
                return true;
            }
            return false;
        }
        public void DisplayCartItems(ProductList productList)
        {
            if (cartItems.Count == 0)
            {
                Console.WriteLine("The shopping cart is empty.");
            }
            else
            {
                Console.WriteLine("Items in the shopping cart:");
                foreach (CartItem cartItem in cartItems)
                {
                    Product product = productList.GetProductById(cartItem.ProductId);
                    Console.WriteLine($"Product: {product.Name}, Quantity: {cartItem.Quantity}, Total Price: {product.Price * cartItem.Quantity}");
                }
            }
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public void Checkout(ProductList productList)
        {
            decimal totalPrice = 0;

        }

        public bool IsEmpty()
        {
            return cartItems.Count == 0;
        }

    }

}
