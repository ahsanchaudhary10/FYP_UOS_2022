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
    
    public partial class Student_Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_Task()
        {
            this.Task_Data = new HashSet<Task_Data>();
        }
    
        public int Task_id { get; set; }
        public string Task_Name { get; set; }
        public System.DateTime Task_start_date { get; set; }
        public System.DateTime Task_end_Date { get; set; }
        public bool Task_status { get; set; }
        public int Group_fid { get; set; }
    
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task_Data> Task_Data { get; set; }
    }
}