using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Secrets
{
    public interface IUow
    {
        void Commit();

        IRepository<User> Users { get; }
        IRepository<Password> Passwords { get; }
    }
}
