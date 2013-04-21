using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Laurus.Secrets
{
    public class Database : DbContext, IDatabase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}