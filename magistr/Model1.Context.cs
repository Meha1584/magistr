﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace magistr
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TutoringCenterEntities : DbContext
    {
        public TutoringCenterEntities()
            : base("name=TutoringCenterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<PositionList> PositionList { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentActivity> StudentActivity { get; set; }
        public virtual DbSet<StudentOfWell> StudentOfWell { get; set; }
        public virtual DbSet<SubjectOfWell> SubjectOfWell { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Well> Well { get; set; }
    }
}
