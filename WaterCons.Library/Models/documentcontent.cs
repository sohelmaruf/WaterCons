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
    
    public partial class documentcontent
    {
        public int ID { get; set; }
        public Nullable<int> DocumentID { get; set; }
        public string Content { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ModBy { get; set; }
        public Nullable<System.DateTime> ModDate { get; set; }
    
        public virtual documentation documentation { get; set; }
    }
}
