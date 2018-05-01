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
    
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            this.cases = new HashSet<@case>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string AccountType { get; set; }
        public Nullable<int> PropertyID { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<int> AccountHolderID { get; set; }
        public Nullable<int> AccountHolderOrg { get; set; }
        public string SICCode { get; set; }
        public string NAICSCode { get; set; }
        public string RevenueClass { get; set; }
        public Nullable<System.DateTime> OpenedDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public string Status { get; set; }
        public Nullable<bool> HasLien { get; set; }
        public Nullable<bool> Affadavit { get; set; }
        public Nullable<bool> PayNoPay { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> LockUpdate { get; set; }
        public string CreateFlag { get; set; }
        public string OldAccountNumber { get; set; }
        public Nullable<bool> CAP { get; set; }
        public string CompanyName { get; set; }
        public Nullable<float> FlowFactor { get; set; }
        public Nullable<bool> LowIncome { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModBy { get; set; }
        public System.DateTime ModDate { get; set; }
    
        public virtual client client { get; set; }
        public virtual property property { get; set; }
        public virtual person person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases { get; set; }
    }
}
