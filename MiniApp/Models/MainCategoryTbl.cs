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
    
    public partial class MainCategoryTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainCategoryTbl()
        {
            this.CategoryTbls = new HashSet<CategoryTbl>();
        }
    
        public long MainCategoryID { get; set; }
        public string MainCategory { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryTbl> CategoryTbls { get; set; }
    }
}
