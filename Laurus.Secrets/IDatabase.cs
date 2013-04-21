using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Secrets
{
    public interface IDatabase
    {
        DbSet<User> Users { get; set; }
        DbSet<Password> Passwords { get; set; }
    }
}
