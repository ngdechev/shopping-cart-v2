using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.commands
{
    interface ICommand
    {
        void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart);
        void Help();
    }
}
