using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebside.ViewModel
{
    public class itemViewModel
    {
        public System.Guid ItemId { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase imagePath { get; set; }
        public Nullable<int> itemPrice { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}