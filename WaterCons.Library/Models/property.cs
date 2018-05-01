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
    
    public partial class property
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public property()
        {
            this.accounts = new HashSet<account>();
            this.cases = new HashSet<@case>();
            this.propertiesservices = new HashSet<propertiesservice>();
            this.propertyowners = new HashSet<propertyowner>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> RandomID { get; set; }
        public string BlockNo { get; set; }
        public string LotNo { get; set; }
        public string AccountBase { get; set; }
        public string PremiseNum { get; set; }
        public string PIN { get; set; }
        public string APN { get; set; }
        public string TaxID { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string UnitNum { get; set; }
        public string StreetNo { get; set; }
        public Nullable<int> StreetNoFrom { get; set; }
        public Nullable<int> StreetNoTo { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string StreetDir { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Jurisdiction { get; set; }
        public string State { get; set; }
        public string RegioninCountry { get; set; }
        public string Country { get; set; }
        public string RegioninWorld { get; set; }
        public string ResidenceType { get; set; }
        public string Category { get; set; }
        public string UsageType { get; set; }
        public Nullable<int> YearBuilt { get; set; }
        public Nullable<int> PropertyTypeID { get; set; }
        public string LandType { get; set; }
        public Nullable<int> NumOfUnits { get; set; }
        public Nullable<bool> Certified { get; set; }
        public Nullable<System.DateTime> LastAffidavitDate { get; set; }
        public string FloorNumber { get; set; }
        public Nullable<bool> Occupied { get; set; }
        public Nullable<int> LotSize { get; set; }
        public string Description { get; set; }
        public Nullable<int> NumOfOccupants { get; set; }
        public Nullable<bool> LowIncome { get; set; }
        public Nullable<float> FlowFactor { get; set; }
        public Nullable<bool> CityorSub { get; set; }
        public string ImportTapNo { get; set; }
        public string RestrictedDesc { get; set; }
        public Nullable<int> CaseNumber { get; set; }
        public Nullable<int> ContactPersonID { get; set; }
        public string MasterType { get; set; }
        public string ParcelSection { get; set; }
        public string ParcelTownship { get; set; }
        public string ParcelRange { get; set; }
        public string ParcelSubdivision { get; set; }
        public string ParcelDistrict { get; set; }
        public string GIS_Subdivision_Name { get; set; }
        public string GIS_Subdivision_No { get; set; }
        public string GIS_Subdivision_Plat { get; set; }
        public string GIS_Subdivision_Page { get; set; }
        public Nullable<decimal> GIS_ParcelValue { get; set; }
        public Nullable<int> LivingArea { get; set; }
        public string Commissioner_Name { get; set; }
        public string Commissioner_District { get; set; }
        public string WaterMgtDistrict { get; set; }
        public Nullable<int> NumBuildings { get; set; }
        public string GroupName { get; set; }
        public Nullable<bool> LockUpdate { get; set; }
        public string PropertyTypeCustomersName { get; set; }
        public Nullable<bool> OwnerOccOrRental { get; set; }
        public string PremiseNumOLD { get; set; }
        public string BldgSizeGross { get; set; }
        public string RevClassCode { get; set; }
        public string EstimatedIrrArea { get; set; }
        public Nullable<int> NumUnitsActual { get; set; }
        public Nullable<int> NumOccupantsActual { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public Nullable<System.DateTime> RecordationDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime ModDate { get; set; }
        public int ModBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@case> cases { get; set; }
        public virtual client client { get; set; }
        public virtual person person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<propertiesservice> propertiesservices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<propertyowner> propertyowners { get; set; }
    }
}