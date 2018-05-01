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
    
    public partial class organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organization()
        {
            this.cases = new HashSet<@case>();
            this.educationalmaterials = new HashSet<educationalmaterial>();
            this.educationalvisitcases = new HashSet<educationalvisitcas>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Attn { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string PhoneArea { get; set; }
        public string EMail { get; set; }
        public string Fax { get; set; }
        public string FaxArea { get; set; }
        public string Webpage { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModDate { get; set; }
        public int ModBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<educationalmaterial> educationalmaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<educationalvisitcas> educationalvisitcases { get; set; }
    }
}