﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dist23Bridge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Dist23BridgeEntities : DbContext
    {
        public Dist23BridgeEntities()
            : base("name=Dist23BridgeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BridgeLink> BridgeLinks { get; set; }
        public virtual DbSet<Bridger> Bridgers { get; set; }
        public virtual DbSet<Jail> Jails { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
    }
}