using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Secrets.Models
{
    public class RegistrationResult
    {
        public bool Result { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
    }
}