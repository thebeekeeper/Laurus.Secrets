using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laurus.Secrets.Models;

namespace Laurus.Secrets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var password = collection["password"];
            Models.User user = default(User);
            using (var db = new Database())
            {
                user = db.Users.FirstOrDefault(u => u.Email.Equals(username, StringComparison.OrdinalIgnoreCase));
                var e = new Encrypter();
                if (e.HashPassword(password) != user.MasterPassword)
                {
                    throw new UnauthorizedAccessException("Wrong password");
                }
            }
            if (user == default(User))
            {
                throw new Exception("user not found");
            }
            Response.SetCookie(new HttpCookie("password", password));
            Response.SetCookie(new HttpCookie("userid", user.UserId.ToString()));

            var rval = RedirectToAction("Index", "Secret");
            return rval;
        }
    }
}
