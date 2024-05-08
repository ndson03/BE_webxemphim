﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetflixClone.Models;
using System.Data.Entity.Validation;
using System.Text;
using System.Data.Entity.Infrastructure;
using Microsoft.SqlServer.Server;
using System.Security.Cryptography;

namespace NetflixClone.Controllers
{
    public class SignupController : Controller
    {
        private Model1 db = new Model1();
        Encrypted.EncryptedList list;

        public SignupController()
        {
            if (!RSAEncryption.isInit)
            {
                RSAEncryption.InitializeRSA();
            }
        }

        // GET: Signup
        public ActionResult Index()
        {
            return View("Create");
        }

        // GET: Signup/Details/5
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

        // GET: Signup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public ActionResult Create([Bind(Include = "userID, userName, password, fullName, birthday, gender, profileImage, email")] user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    list = new Encrypted.EncryptedList();
                    // Encrypt the email and password before saving to the database
                    Encrypted encrypted = new Encrypted(RSAEncryption.Encrypt(user.email), RSAEncryption.Encrypt(user.password));
                    list.Add(encrypted);
                    var userCount = db.users.Count();
                    user.userID = userCount + 1;
                    //comment email với password khi nào chạy thì bỏ cmt
                    user.email = encrypted.encryptedEmail;
                    user.password = encrypted.encryptedPassword;
                    //Console.WriteLine();
                    if (user.birthday == null || user.profileImage == null || user.gender == null || user.userName == null || user.fullName == null)
                    {
                        user.userName = "";
                        user.birthday = DateTime.Now;
                        user.profileImage = "";
                        user.gender = 1;
                    }

                    user.profileImage = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/Content/UserImages/" + fileName);
                        f.SaveAs(uploadPath);
                        user.profileImage = fileName;
                    }
                    db.users.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ViewBag.Error = "There was an error: " + e.Message;
                return View(user);
            }
        }*/

        public ActionResult Create(string fullname, string email, string password)
        {
            user usernew = new user();
            try
            {
                list = new Encrypted.EncryptedList();
                if (ModelState.IsValid)
                {
                    // Encrypt the email and password before saving to the database
                    Encrypted encrypted = new Encrypted(RSAEncryption.Encrypt(email), RSAEncryption.Encrypt(password));
                    list.Add(encrypted);
                    var userCount = db.users.Count();
                    usernew.userID = userCount + 1;
                    //comment email với password khi nào chạy thì bỏ cmt
                    usernew.email = encrypted.encryptedEmail;
                    usernew.password = encrypted.encryptedPassword;
                    //Console.WriteLine();
                        usernew.userName = fullname;
                        usernew.birthday = DateTime.Now;
                        usernew.profileImage = "";
                        usernew.gender = 1;
                    

                    /*user.profileImage = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/Content/UserImages/" + fileName);
                        f.SaveAs(uploadPath);
                        user.profileImage = fileName;
                    }*/
                    db.users.Add(usernew);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ViewBag.Error = "There was an error: " + e.Message;
                return View(usernew);
            }
        }

        // GET: Signup/Edit/5
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

        // POST: Signup/Edit/5
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

        // GET: Signup/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Signup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
