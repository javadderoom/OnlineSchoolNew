//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tamarin
    {
        public Tamarin()
        {
            this.JavabeTamrins = new HashSet<JavabeTamrin>();
        }
    
        public int TamrinID { get; set; }
        public string TamrinTitle { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public string Description { get; set; }
        public byte[] fileData { get; set; }
    
        public virtual ICollection<JavabeTamrin> JavabeTamrins { get; set; }
        public virtual LessonGroup LessonGroup { get; set; }
    }
}
