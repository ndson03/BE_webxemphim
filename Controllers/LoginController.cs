using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetflixClone.Models;

namespace NetflixClone.Controllers
{
    public class LoginController : Controller
    {
        private Model1 db = new Model1();

        public LoginController()
        {
            RSAEncryption.InitializeRSA(); // Initialize RSA encryption
        }

        // GET: Login
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(db.users.ToList());
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email or password is empty!";
                return View("Login");
            }
            else
            {
                // Encrypt the email and password before comparing
                string encryptedEmail = RSAEncryption.Encrypt(email);
                string encryptedPassword = RSAEncryption.Encrypt(password);

                var user = db.users.FirstOrDefault(u => u.email == encryptedEmail && u.password == encryptedPassword);
                if (user != null)
                {
                    Session["user"] = user.fullName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid email or password!";
                    return View("Login");
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,userName,password,fullName,birthday,gender,profileImage,email")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
