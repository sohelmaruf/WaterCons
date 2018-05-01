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
    
    public partial class program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public program()
        {
            this.phases = new HashSet<phase>();
            this.programdevicemodels = new HashSet<programdevicemodel>();
            this.programdevicetypes = new HashSet<programdevicetype>();
            this.programinterventiontypes = new HashSet<programinterventiontype>();
            this.programsteps = new HashSet<programstep>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IncludeInMatrix { get; set; }
        public Nullable<bool> Visible { get; set; }
        public Nullable<bool> OwnerDefaultParticipant { get; set; }
        public string Modules { get; set; }
        public string FundingType { get; set; }
        public string Incentives { get; set; }
        public Nullable<bool> DefaultRCCase { get; set; }
        public string DefaultWDOCandidateDeviceType { get; set; }
        public Nullable<int> VoucherValidDays { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModDate { get; set; }
        public int ModBy { get; set; }
        public string EditRetrofitPage { get; set; }
    
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phase> phases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programdevicemodel> programdevicemodels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programdevicetype> programdevicetypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programinterventiontype> programinterventiontypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<programstep> programsteps { get; set; }
    }
}
