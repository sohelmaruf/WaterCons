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
    
    public partial class newslettercontact
    {
        public int ID { get; set; }
        public Nullable<int> NewsLetterID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public string SentBy { get; set; }
    
        public virtual contact contact { get; set; }
        public virtual newsletter newsletter { get; set; }
    }
}
