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
    public class WatchlistController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(int id)
        {
            var viewModel = new MediaListWatchlistModel
            {
                Movies = db.movies.ToList(),
                Series = db.series.ToList(),
                Watchlist = db.watchlists.Where(w => w.userID == id).FirstOrDefault(),
                List_watchlist = db.list_watchlist.ToList(),
            };
            viewModel.List_watchlist = db.list_watchlist.Where(l => l.watchlistID == viewModel.Watchlist.watchlistID).ToList();
            var serieIDs = viewModel.List_watchlist.Select(l => l.serieID).ToList();
            viewModel.Series = viewModel.Series
                .Where(s => serieIDs.Contains(s.serieID))
                .ToList();
            var movieIDs = viewModel.List_watchlist.Select(l => l.movieID).ToList();
            viewModel.Movies = viewModel.Movies
                .Where(s => movieIDs.Contains(s.movieID))
                .ToList();

            foreach (var s in viewModel.Movies)
            {
                s.posterPath = "https://image.tmdb.org/t/p/w500" + s.posterPath;
            }
            foreach (var s in viewModel.Series)
            {
                s.posterPath = "https://image.tmdb.org/t/p/w500" + s.posterPath;
            }
            return View(viewModel);
        }

        public ActionResult Add(int id, int watchlistID)
        {
            list_watchlist watchlistAdd = new list_watchlist();
            Console.WriteLine(id.ToString()+  watchlistID.ToString());
            try
            {
                if (ModelState.IsValid)
                {
                    watchlistAdd.watchlistID = watchlistID;

                    //kiểm tra trùng lặp + kiểm tra id của movie hay serie
                    var movieFind = db.movies.Find(id);
                    var existingWatchlistEntry = db.list_watchlist.SingleOrDefault(w => w.movieID == id && w.watchlistID == watchlistID);
                    if (movieFind != null && existingWatchlistEntry == null)
                    {
                        watchlistAdd.movieID = id;
                    }
                    else
                    {
                        var serieFind = db.series.Find(id);
                        existingWatchlistEntry = db.list_watchlist.SingleOrDefault(w => w.serieID == id && w.watchlistID == watchlistID);
                        if (serieFind != null && existingWatchlistEntry == null)
                        {
                            watchlistAdd.serieID = id;
                        }
                    }

                    //add nếu như không bị trùng lặp
                    if(watchlistAdd.movieID != null || watchlistAdd.serieID != null)
                    {
                        db.list_watchlist.Add(watchlistAdd);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index", "Watchlist", new { id = Session["id"] });
            }
            catch (Exception e)
            {
                ViewBag.Error = "There was an error: " + e.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: /Delete/5
        public ActionResult Delete(int id, int watchlistID)
        {
            list_watchlist moviedel = db.list_watchlist.SingleOrDefault(w => w.movieID == id && w.watchlistID == watchlistID);
            if (moviedel != null) db.list_watchlist.Remove(moviedel);
            else
            {
                list_watchlist seriedel = db.list_watchlist.SingleOrDefault(w => w.serieID == id && w.watchlistID == watchlistID);
                db.list_watchlist.Remove(seriedel);
            }
            db.SaveChanges();
            return RedirectToAction("Index", new { id = Session["id"] });
        }

    }

}
