﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Db_Entities : DbContext
    {
        public Db_Entities()
            : base("name=Db_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Examcell> Examcells { get; set; }
        public virtual DbSet<PMO> PMOes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
    }
}
