![version](https://img.shields.io/badge/version-1.0.0-blue)
![GitHub repo size](https://img.shields.io/github/repo-size/ngdechev/smartbot?color=green)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/ngdechev/library)

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

## Project Development
The following programming languages were used for the development of the project:
1. C#

And the following tools:
1. Visual Studio

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

