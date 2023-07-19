using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.classes.wrapper_classes;

namespace OnlineShop.interfaces
{
    interface ICommand
    {
        void Execute(string[] commandParts, ProductList productList, ShoppingCart shoppingCart);
        void Help();
    }
}
