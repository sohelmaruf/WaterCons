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
    
    public partial class surveyarea
    {
        public int ID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> SurveyCaseID { get; set; }
        public Nullable<int> InterventionID { get; set; }
        public string AreaType { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public Nullable<int> ToiletDeviceID { get; set; }
        public Nullable<int> FaucetDeviceID { get; set; }
        public Nullable<int> ShowerHeadDeviceID { get; set; }
        public Nullable<int> DishWasherID { get; set; }
        public Nullable<int> ClothesWasherID { get; set; }
        public Nullable<int> AreaSize { get; set; }
        public Nullable<int> WaterApplicationRate { get; set; }
        public Nullable<int> PercentIrrigated { get; set; }
        public Nullable<bool> IrrigationCircuit1 { get; set; }
        public Nullable<bool> IrrigationCircuit2 { get; set; }
        public Nullable<bool> IrrigationCircuit3 { get; set; }
        public Nullable<bool> IrrigationCircuit4 { get; set; }
        public Nullable<bool> IrrigationCircuit5 { get; set; }
        public Nullable<bool> IrrigationCircuit6 { get; set; }
        public Nullable<bool> IrrigationCircuit7 { get; set; }
        public Nullable<bool> IrrigationCircuit8 { get; set; }
        public Nullable<bool> IrrigationCircuit9 { get; set; }
        public Nullable<bool> IrrigationCircuit10 { get; set; }
        public Nullable<bool> IrrigationCircuit11 { get; set; }
        public Nullable<bool> IrrigationCircuit12 { get; set; }
        public string PlantType1 { get; set; }
        public string PlantType2 { get; set; }
        public string PlantType3 { get; set; }
        public Nullable<int> PlantType1Percent { get; set; }
        public Nullable<int> PlantType3Percent { get; set; }
        public Nullable<int> PlantType2Percent { get; set; }
        public string SoilType { get; set; }
        public string Slope { get; set; }
        public string SunExposure { get; set; }
        public Nullable<float> PotentialSavings { get; set; }
        public Nullable<decimal> FlowRate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModBy { get; set; }
        public Nullable<System.DateTime> ModDate { get; set; }
    
        public virtual @case @case { get; set; }
        public virtual client client { get; set; }
        public virtual device device { get; set; }
        public virtual device device1 { get; set; }
        public virtual device device2 { get; set; }
        public virtual device device3 { get; set; }
        public virtual device device4 { get; set; }
        public virtual intervention intervention { get; set; }
    }
}
