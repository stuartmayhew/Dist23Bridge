using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dist23Bridge.Models;


namespace Dist23Bridge.Models
{
    public class BridgeData:DbContext
    {
        public BridgeData()
            : base("Name=BridgeData")
        {
            Database.SetInitializer<BridgeData>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BridgeLinks> BridgeLinks { get; set; }
        public DbSet<Bridgers> Bridgers { get; set; }
        public DbSet<Jails> Jails { get; set; }
        public DbSet<Volunteers> Volunteers { get; set; }
    }
}