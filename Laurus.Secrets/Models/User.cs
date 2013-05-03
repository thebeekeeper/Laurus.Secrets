using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Secrets.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string MobileCode { get; set; }
        public string PasswordHash { get; set; }

        public virtual List<Password> Passwords { get; set; }
    }
}