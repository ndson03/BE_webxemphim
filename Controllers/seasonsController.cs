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
    public class seasonsController : Controller
    {
        private Model1 db = new Model1();

        // GET: seasons
        public ActionResult Index(int id)
        {
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: seasons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // GET: seasons/Create
        public ActionResult Create()
        {
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName");
            return View();
        }

        // POST: seasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "seasonID,seasonName,seasonNumber,overview,posterPath,trailer,voteAverage,voteCount,serieID")] season season)
        {
            if (ModelState.IsValid)
            {
                db.seasons.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", season.serieID);
            return View(season);
        }

        // GET: seasons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", season.serieID);
            return View(season);
        }

        // POST: seasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "seasonID,seasonName,seasonNumber,overview,posterPath,trailer,voteAverage,voteCount,serieID")] season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", season.serieID);
            return View(season);
        }

        // GET: seasons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            season season = db.seasons.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        // POST: seasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            season season = db.seasons.Find(id);
            db.seasons.Remove(season);
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
