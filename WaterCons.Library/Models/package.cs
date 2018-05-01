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
    
    public partial class package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public package()
        {
            this.clients = new HashSet<client>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> UserLimit { get; set; }
        public Nullable<int> PropertiesLimit { get; set; }
        public Nullable<int> AccountLimit { get; set; }
        public Nullable<bool> AllowUrl { get; set; }
        public Nullable<bool> EmailSupport { get; set; }
        public Nullable<bool> PhoneSupport { get; set; }
        public Nullable<bool> OnsiteSupport { get; set; }
        public Nullable<bool> DataMigration { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client> clients { get; set; }
    }
}
