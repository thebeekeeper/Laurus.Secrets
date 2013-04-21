using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Laurus.Secrets
{
    public class SecretsDbContext : DbContext
    {
        public SecretsDbContext()
            : base(nameOrConnectionString: "Default")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Password> Passwords { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class DatabaseInitializer
    {
    }
}