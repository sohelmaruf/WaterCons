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
    
    public partial class phase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phase()
        {
            this.cases = new HashSet<@case>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public int ProgramID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Budget { get; set; }
        public Nullable<long> PredictedWaterSavings { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModDate { get; set; }
        public int ModBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases { get; set; }
        public virtual client client { get; set; }
        public virtual program program { get; set; }
    }
}