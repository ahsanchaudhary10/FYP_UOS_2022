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
    
    public partial class Supervisor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supervisor()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int Supervisor_id { get; set; }
        public string Supervisor_Name { get; set; }
        public string Supervisor_Email { get; set; }
        public string Supervisor_Password { get; set; }
        public Nullable<int> PMO_FID { get; set; }
    
        public virtual PMO PMO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}