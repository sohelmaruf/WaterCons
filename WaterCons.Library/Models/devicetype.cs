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
    
    public partial class devicetype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public devicetype()
        {
            this.deviceefficiencylevels = new HashSet<deviceefficiencylevel>();
            this.devicemodels = new HashSet<devicemodel>();
            this.programdevicetypes = new HashSet<programdevicetype>();
            this.savingsfactors = new HashSet<savingsfactor>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public string Type { get; set; }
        public Nullable<long> DefaultSavingsFactor { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModBy { get; set; }
        public System.DateTime ModDate { get; set; }
    
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deviceefficiencylevel> deviceefficiencylevels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<devicemodel> devicemodels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programdevicetype> programdevicetypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<savingsfactor> savingsfactors { get; set; }
    }
}
