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
    
    public partial class programdevicemodel
    {
        public int ID { get; set; }
        public int ProgramID { get; set; }
        public int DeviceModelID { get; set; }
        public Nullable<bool> IsNew { get; set; }
    
        public virtual devicemodel devicemodel { get; set; }
        public virtual program program { get; set; }
    }
}