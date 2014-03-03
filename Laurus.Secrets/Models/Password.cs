using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurus.Secrets.Models
{
    // TODO: create user/password entities, map from those to the models for display
    public class Password
    {
        public int PasswordId { get; set; }
        public string EncryptedData { get; set; }
		public KeyValuePair<string, string>[] Fields { get; set; }
        public string Label { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

		public Password()
		{
		}
    }
}