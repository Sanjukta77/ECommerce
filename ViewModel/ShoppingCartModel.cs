using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebside.ViewModel
{
    public class ShoppingCartModel
    {

        public string itemId { get; set; }
        public int quantity { get; set; }
        public int unitPrice { get; set; }
        public int Total { get; set; }
        public string itemName { get; set; }
        public string imagePath { get; set; }

        public string imageName { get; set; }

        

    }
}