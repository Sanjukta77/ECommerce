using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceWebside.ViewModel
{
    public class shoppingViewModel
    {
        public System.Guid ItemId { get; set; }          
        public string itemName { get; set; }
        public string Description { get; set; }
        public string imagePath { get; set; }
        public Nullable<int> itemPrice { get; set; }
        public string category { get; set; }
    }
}