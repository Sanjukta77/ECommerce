//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcommerceWebside.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<System.Guid> ItemId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> UnitPrice { get; set; }
    }
}