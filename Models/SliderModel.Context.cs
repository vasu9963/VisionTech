﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestTemplate.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class templatetestEntities1 : DbContext
    {
        public templatetestEntities1()
            : base("name=templatetestEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Slidertable> Slidertables { get; set; }
        public virtual DbSet<Categorytable> Categorytables { get; set; }
        public virtual DbSet<Abouttable> Abouttables { get; set; }
        public virtual DbSet<Contacttable> Contacttables { get; set; }
        public virtual DbSet<Recipevideotable> Recipevideotables { get; set; }
        public virtual DbSet<Adminlogin> Adminlogins { get; set; }
    }
}
