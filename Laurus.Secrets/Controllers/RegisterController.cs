using Laurus.Secrets.Models;
using System;
using System.Web.Mvc;

namespace Laurus.Secrets.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController(IUow uow)
        {
            _uow = uow;
        }

        public RegisterController()
            : this(new Uow(new RepositoryProvider(new RepositoryFactories())))
        { }

        public ViewResult Index(string email, string masterPassword)
        {
            return View(new Models.User());
        }

        public ActionResult Create(Models.User newUser)
        {
            //newUser.MasterPassword = new Encrypter().HashPassword(newUser.MasterPassword);
            //_uow.Users.Add(newUser);
            //_uow.Commit();
            //return user.UserId;
            return View();
        }

        private IUow _uow;
    }
}
