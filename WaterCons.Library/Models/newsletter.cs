//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaterCons.Library.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class newsletter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public newsletter()
        {
            this.newslettercontacts = new HashSet<newslettercontact>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NewsLetterContent { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string ModDate { get; set; }
        public Nullable<int> ModBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newslettercontact> newslettercontacts { get; set; }
    }
}
