//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartTbl
    {
        public long CartID { get; set; }
        public Nullable<long> UserID { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual ProductTbl ProductTbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}
