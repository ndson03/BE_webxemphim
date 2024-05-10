using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NetflixClone.Models;

namespace NetflixClone.Controllers
{
    public class LoginController : Controller
    {
        private Model1 db = new Model1();

        public LoginController()
        {
            //RSAEncryption.InitializeRSA(); // Initialize RSA encryption
            if (!RSAEncryption.isInit)
            {
                RSAEncryption.InitializeRSA();
            }
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
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

                foreach (var user in db.users)
                {
                    Console.WriteLine(user.email);
                    string decryptedEmail = RSAEncryption.Decrypt(user.email);
                    
                    string decryptedPassword = RSAEncryption.Decrypt(user.password);
                    if (decryptedEmail == email && decryptedPassword == password)
                    {
                        Session["user"] = user.fullName;
                        Session["id"] = user.userID;
                        return RedirectToAction("Index", "Home");
                    }
                }
                    ViewBag.Error = "Invalid email or password!";
                    return View("Login");
                
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            Session.Remove("id");
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
        public ActionResult Edit(int userID, string userName, string email, string password, string fullName, DateTime birthday, int gender, string profileImage)
        {
            user userupd = new user();
            userupd.userID = userID;
            userupd.userName = userName;
            userupd.password = RSAEncryption.Encrypt(password);
            userupd.gender = gender;
            userupd.fullName = fullName;
            userupd.birthday = birthday;
            userupd.profileImage = profileImage;
            userupd.email = RSAEncryption.Encrypt(email);
            if (ModelState.IsValid)
            {
                db.Entry(userupd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userupd);
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
