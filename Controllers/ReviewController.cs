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
    public class ReviewController : Controller
    {
        private Model1 db = new Model1();

        [HttpPost]
        public ActionResult Add(string name, string email, string message, int id)
        {
            int reviewCount = db.reviews.Count();
            review newreview = new review();
            newreview.reviewID = reviewCount + 1;
            newreview.content = message;
            newreview.timestamp = DateTime.Now.ToString();
            newreview.userID = (int?)Session["id"];
            newreview.movieID = id;
            try
            {
                db.reviews.Add(newreview);
                db.SaveChanges();
            }
            catch {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("PlayMovie", "movies", new { id = id });
        }

        public ActionResult Delete(int id, int movieid)
        {

            review reviewdel = db.reviews.SingleOrDefault(r => r.reviewID == id);
            db.reviews.Remove(reviewdel);
            db.SaveChanges();
            return RedirectToAction("PlayMovie", "movies", new { id = movieid });
        }

    }

}
