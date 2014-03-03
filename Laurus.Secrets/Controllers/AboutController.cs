using Laurus.Secrets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Secrets.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

        public ActionResult Index()
        {
			var v = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			return View(new AboutModel() { Version = v });
        }

    }
}
