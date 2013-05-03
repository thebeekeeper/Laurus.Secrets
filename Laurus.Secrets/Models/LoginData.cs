using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Secrets.Models
{
    public class LoginData
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}