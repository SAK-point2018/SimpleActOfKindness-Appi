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
    
        public virtual DbSet<SAKkayttaja> SAKkayttaja { get; set; }
        public virtual DbSet<SAKpalkinnontarjoaja> SAKpalkinnontarjoaja { get; set; }
        public virtual DbSet<SAKpalkinto> SAKpalkinto { get; set; }
        public virtual DbSet<SAKtehdytteot> SAKtehdytteot { get; set; }
        public virtual DbSet<SAKteot> SAKteot { get; set; }
        public virtual DbSet<tblImage> tblImage { get; set; }
    }
}
