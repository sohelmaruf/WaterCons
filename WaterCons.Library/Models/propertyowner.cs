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
    
    public partial class propertyowner
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public int OwnerID { get; set; }
        public Nullable<bool> IsCurrentOwner { get; set; }
        public Nullable<int> PercentOwnerShip { get; set; }
        public string Organization { get; set; }
    
        public virtual person person { get; set; }
        public virtual property property { get; set; }
    }
}
