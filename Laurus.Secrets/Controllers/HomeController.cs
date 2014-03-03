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
            // clear all cookies so we don't end up with an invalid user id
            Response.Cookies.Clear();
            return View();
        }

        public int Login(LoginData login)
        {
            int userId = -1;
            try
            {
                var d = new Database();
            }
            catch (Exception e)
           { 
                throw new Exception(e.Message);
            }
            using (var db = new Database())
            {
                var user = db.Users.FirstOrDefault(u => u.Email.Equals(login.Username, StringComparison.OrdinalIgnoreCase));
                if (user != default(User) && user.PasswordHash == login.PasswordHash)
                {
                    userId = user.UserId;
                    Response.SetCookie(new HttpCookie("userid", userId.ToString()));
                }
            }
            return userId;
        }

        public JsonResult Register(LoginData login)
        {
            var result = new RegistrationResult();

            try
            {
                int userId = -1;
                using (var db = new Database())
                {
                    if (db.Users.Any(u => u.Email.Equals(login.Username, StringComparison.OrdinalIgnoreCase)))
                    {
                        result.Result = false;
                        result.Message = "Username already taken";
                        result.UserId = -1;
                    }
                    else
                    {
                        var user = new User()
                        {
                            Email = login.Username,
                            PasswordHash = login.PasswordHash
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                        userId = user.UserId;
                        result.Result = true;
                        result.UserId = user.UserId;
                    }
                }
                Response.SetCookie(new HttpCookie("userid", userId.ToString()));
            }
            catch (Exception e)
            {
                throw new Exception("register failed");
            }
            return this.Json(result);
        }
        
        //public ActionResult Login(FormCollection collection)
        //{
        //    var username = collection["username"];
        //    var password = collection["password"];
        //    Models.User user = default(User);
        //    using (var db = new Database())
        //    {
        //        user = db.Users.FirstOrDefault(u => u.Email.Equals(username, StringComparison.OrdinalIgnoreCase));
        //        var e = new Encrypter();
        //        //if (e.HashPassword(password) != user.MasterPassword)
        //        if(e.HashPassword(password) == string.Empty)
        //        {
        //            throw new UnauthorizedAccessException("Wrong password");
        //        }
        //        if (user == default(User))
        //        {
        //            user = db.Users.Add(new User() { Email = username });
        //            db.SaveChanges();
        //        }
        //    }
        //    Response.SetCookie(new HttpCookie("key", password));
        //    Response.SetCookie(new HttpCookie("userid", user.UserId.ToString()));

        //    var rval = RedirectToAction("Index", "Secret");
        //    return rval;
        //}
    }
}
