//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYP_UOS_2022.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task_Assign
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task_Assign()
        {
            this.Task_Data = new HashSet<Task_Data>();
        }
    
        public int id { get; set; }
        public int Group_fid { get; set; }
        public int Task_fid { get; set; }
        public System.DateTime Assign_Date { get; set; }
    
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task_Data> Task_Data { get; set; }
        public virtual Student_Task Student_Task1 { get; set; }
    }
}