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
    public class episodesController : Controller
    {
        private Model1 db = new Model1();

        // GET: episodes
        public ActionResult Index()
        {
            var episodes = db.episodes.Include(e => e.season).Include(e => e.series);
            return View(episodes.ToList());
        }

        // GET: episodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        // GET: episodes/Create
        public ActionResult Create()
        {
            ViewBag.seasonID = new SelectList(db.seasons, "seasonID", "seasonName");
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName");
            return View();
        }

        // POST: episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "episodeID,episodeName,episodeNumber,overview,posterPath,trailer,voteAverage,voteCount,runtime,seasonID,serieID")] episode episode)
        {
            if (ModelState.IsValid)
            {
                db.episodes.Add(episode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.seasonID = new SelectList(db.seasons, "seasonID", "seasonName", episode.seasonID);
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", episode.serieID);
            return View(episode);
        }

        // GET: episodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            ViewBag.seasonID = new SelectList(db.seasons, "seasonID", "seasonName", episode.seasonID);
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", episode.serieID);
            return View(episode);
        }

        // POST: episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "episodeID,episodeName,episodeNumber,overview,posterPath,trailer,voteAverage,voteCount,runtime,seasonID,serieID")] episode episode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(episode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.seasonID = new SelectList(db.seasons, "seasonID", "seasonName", episode.seasonID);
            ViewBag.serieID = new SelectList(db.series, "serieID", "serieName", episode.serieID);
            return View(episode);
        }

        // GET: episodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            episode episode = db.episodes.Find(id);
            if (episode == null)
            {
                return HttpNotFound();
            }
            return View(episode);
        }

        // POST: episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            episode episode = db.episodes.Find(id);
            db.episodes.Remove(episode);
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
