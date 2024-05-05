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
    public class seriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: series
        public ActionResult Index()
        {
            return View(db.series.ToList());
        }

        // GET: series/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }

            ViewBag.SerieID = id;

            return View(series);
        }


        // GET: series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serieID,serieName,originalSerieName,firstAirDate,lastAirDate,status,tagline,overview,homepage,popularity,voteAverage,voteCount,posterPath,backdropPath,trailer,numberOfSeasons,numberOfEpisodes,runtime,originalLanguage,type,tags,adult,genreID")] series series)
        {
            if (ModelState.IsValid)
            {
                db.series.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(series);
        }

        // GET: series/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "serieID,serieName,originalSerieName,firstAirDate,lastAirDate,status,tagline,overview,homepage,popularity,voteAverage,voteCount,posterPath,backdropPath,trailer,numberOfSeasons,numberOfEpisodes,runtime,originalLanguage,type,tags,adult,genreID")] series series)
        {
            if (ModelState.IsValid)
            {
                db.Entry(series).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(series);
        }

        // GET: series/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            series series = db.series.Find(id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            series series = db.series.Find(id);
            db.series.Remove(series);
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
