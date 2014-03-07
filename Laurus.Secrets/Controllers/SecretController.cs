using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laurus.Secrets.Models;

namespace Laurus.Secrets.Controllers
{
    public class SecretController : Controller
    {
        private Database db = new Database();

        //
        // GET: /Secret/

        public ActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.Request.Cookies["userId"].Value);

			var passwords = db.Passwords
				.Where(p => p.UserId == userId)
				.Include(p => p.User);
            return View(passwords.ToList());
        }

        //
        // GET: /Secret/Details/5

        public ActionResult Details(int id = 0)
        {
            Password password = db.Passwords.Find(id);
            if (password == null)
            {
                return HttpNotFound();
            }
            return View(password);
        }

        //
        // GET: /Secret/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email");
			var fields = new List<KeyValuePair<string, string>>()
			{
				new KeyValuePair<string, string>("Name", ""),
				new KeyValuePair<string, string>("Username", ""),
				new KeyValuePair<string, string>("Password", ""), 
				new KeyValuePair<string, string>("Notes", "" ) 
			};
			var model = new Password() { Fields = fields.ToArray() };
            return View(model);
        }

        //
        // POST: /Secret/Create

        [HttpPost]
        public ActionResult Create(Password password)
        {
            if (ModelState.IsValid)
            {
                var userId = Int32.Parse(Request.Cookies.Get("userid").Value);
                password.UserId = userId;
                db.Passwords.Add(password);
                db.SaveChanges();
            }
			// js actually does the redirect, so this is kind of useless
			return RedirectToAction("Index");
        }

        //
        // GET: /Secret/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Password password = db.Passwords.Find(id);
            if (password == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", password.UserId);
            return View(password);
        }

        //
        // POST: /Secret/Edit/5

        [HttpPost]
        public ActionResult Edit(Password password)
        {
            if (ModelState.IsValid)
            {
                db.Entry(password).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Email", password.UserId);
            return View(password);
        }

        //
        // GET: /Secret/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Password password = db.Passwords.Find(id);
            if (password == null)
            {
                return HttpNotFound();
            }
            return View(password);
        }

        //
        // POST: /Secret/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Password password = db.Passwords.Find(id);
            db.Passwords.Remove(password);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}