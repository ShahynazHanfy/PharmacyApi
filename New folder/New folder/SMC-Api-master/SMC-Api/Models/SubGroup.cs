//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMC_Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subgroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subgroup()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string image { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
