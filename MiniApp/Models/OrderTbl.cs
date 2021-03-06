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
    
    public partial class OrderTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderTbl()
        {
            this.OrderDetTbls = new HashSet<OrderDetTbl>();
            this.OrderDispatchTbls = new HashSet<OrderDispatchTbl>();
        }
    
        public long OrderID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<long> UserID { get; set; }
        public Nullable<int> PaymentMode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetTbl> OrderDetTbls { get; set; }
        public virtual UserTbl UserTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDispatchTbl> OrderDispatchTbls { get; set; }
    }
}
