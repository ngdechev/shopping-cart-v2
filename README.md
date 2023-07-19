# Shopping Cart
## Description
Implement a simple text-based application that emulates a shopping cart.

## Requirements
- The application must be text-based (console application) and all user input must be implemented as commands that the user types on the keyboard.
- The application must provide a list of products and a shopping cart with items and quantities
- The list of products must be saved and loaded to/from the file system
- The application must define two user roles with different access rights:
  - Administrator - a user that can administer the product list i.e. add new products, change quantities, edit and delete a product
  - Customer - a user that can only select products for the shopping cart and specify quantities to buy
## List of available commands
- addProduct
- removeProduct
- editProduct
- listProducts
- searchProducts
- addCartItem
- removeCartItem
- updateCartItem
- listCartItems
- checkout
- help
- exit
- login (optional; user role selection may be implemented at application startup)
## Entity classes fields
**Product fields**
- Id
- Article name
- Description
- Price
- Available Quantity

**Cart item fields**
- Id
- Product Id
- Quantity
