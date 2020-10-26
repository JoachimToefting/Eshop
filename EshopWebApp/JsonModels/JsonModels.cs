using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopWebApp.JsonModels
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string Count { get; set; }
    }

    public class Root
    {
        public CartItem CartItem { get; set; }
    }
}
