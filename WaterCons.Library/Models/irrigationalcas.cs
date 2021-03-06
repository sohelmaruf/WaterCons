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
    
    public partial class irrigationalcas
    {
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public int CaseID { get; set; }
        public string IrrigationType { get; set; }
        public string ControllerProgrammer { get; set; }
        public Nullable<int> GardenerID { get; set; }
        public string ControllerProgrammerDates { get; set; }
        public Nullable<bool> StickerPosted { get; set; }
        public Nullable<bool> EducationalPacketGiven { get; set; }
        public Nullable<bool> OrdinanceInfoDiscussed { get; set; }
        public Nullable<bool> WaterUsageReviewed { get; set; }
        public Nullable<bool> IrrigationIssuesReviewed { get; set; }
        public Nullable<bool> RunoffOnSite { get; set; }
        public Nullable<bool> DeviceInstalled { get; set; }
        public Nullable<bool> DeviceFunctioning { get; set; }
        public Nullable<bool> LandscapeHealthImproved { get; set; }
        public Nullable<bool> IrrigationIssuesAddressed { get; set; }
        public Nullable<bool> RunoffReduction { get; set; }
        public string UsageRank { get; set; }
        public string AnnUsage { get; set; }
        public string InstallerName { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> NumberOfFlags { get; set; }
        public Nullable<int> LandscapedArea { get; set; }
    
        public virtual @case @case { get; set; }
        public virtual client client { get; set; }
        public virtual person person { get; set; }
    }
}
