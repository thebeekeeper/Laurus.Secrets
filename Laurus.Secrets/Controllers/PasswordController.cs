using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laurus.Secrets.Controllers
{
    public class PasswordController : ApiController
    {
        public PasswordController(IUow uow)
        {
            _uow = uow;
        }

        // GET api/password
        public IEnumerable<Password> Get()
        {
            return _uow.Passwords.GetAll();
        }

        // GET api/password/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/password
        public void Post([FromBody]string value)
        {
        }

        // PUT api/password/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/password/5
        public void Delete(int id)
        {
        }

        private IUow _uow;
    }
}
