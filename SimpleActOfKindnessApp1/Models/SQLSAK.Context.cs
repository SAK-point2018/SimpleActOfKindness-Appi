﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleActOfKindnessApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ScrumDB2018KEntities : DbContext
    {
        public ScrumDB2018KEntities()
            : base("name=ScrumDB2018KEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SAKkayttaja> SAKkayttajas { get; set; }
        public virtual DbSet<SAKpalkinnontarjoaja> SAKpalkinnontarjoajas { get; set; }
        public virtual DbSet<SAKpalkinto> SAKpalkintoes { get; set; }
        public virtual DbSet<SAKtehdytteot> SAKtehdytteots { get; set; }
        public virtual DbSet<SAKteot> SAKteots { get; set; }
        public virtual DbSet<tblImage> tblImages { get; set; }
    }
}
