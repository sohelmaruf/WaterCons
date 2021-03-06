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
    
    public partial class person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            this.accounts = new HashSet<account>();
            this.campaignmaterials = new HashSet<campaignmaterial>();
            this.casecontacts = new HashSet<casecontact>();
            this.cases = new HashSet<@case>();
            this.cases1 = new HashSet<@case>();
            this.cases2 = new HashSet<@case>();
            this.educationalmaterials = new HashSet<educationalmaterial>();
            this.educationalvisitcases = new HashSet<educationalvisitcas>();
            this.events = new HashSet<@event>();
            this.irrigationalcases = new HashSet<irrigationalcas>();
            this.peoplepeopletypes = new HashSet<peoplepeopletype>();
            this.properties = new HashSet<property>();
            this.propertyowners = new HashSet<propertyowner>();
            this.violationcases = new HashSet<violationcas>();
            this.violationcases1 = new HashSet<violationcas>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Attn { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string HomePhoneArea { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhoneArea { get; set; }
        public string Cell { get; set; }
        public string CellArea { get; set; }
        public string Fax { get; set; }
        public string FaxArea { get; set; }
        public string EMail { get; set; }
        public string Title { get; set; }
        public string ContactMethod { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string Comments { get; set; }
        public Nullable<int> ImportID { get; set; }
        public string ImportBlockNo { get; set; }
        public string ImportLotNo { get; set; }
        public string ImportAccountNumber { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ImportCaseID { get; set; }
        public string PremiseNumber { get; set; }
        public string ParcelNumber { get; set; }
        public string SSNNumber { get; set; }
        public string Country { get; set; }
        public Nullable<bool> LockUpdate { get; set; }
        public Nullable<int> EducationalVisitID { get; set; }
        public string TempAccountNumber { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModBy { get; set; }
        public System.DateTime ModDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaignmaterial> campaignmaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<casecontact> casecontacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases2 { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<educationalmaterial> educationalmaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<educationalvisitcas> educationalvisitcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@event> events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<irrigationalcas> irrigationalcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<peoplepeopletype> peoplepeopletypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<property> properties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<propertyowner> propertyowners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<violationcas> violationcases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<violationcas> violationcases1 { get; set; }
    }
}
