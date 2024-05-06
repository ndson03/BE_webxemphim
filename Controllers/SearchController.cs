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
    public class SearchController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index(string query)
        {
            var viewModel = new MediaListViewModel
            {
                Movies = db.movies.ToList(),
                Series = db.series.ToList()
            };
            if (!String.IsNullOrEmpty(query))
            {
                viewModel.Series = viewModel.Series.Where(s => s.serieName.Contains(query)).ToList();
                viewModel.Movies = viewModel.Movies.Where(m => m.movieName.Contains(query)).ToList();
            }
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


    }

}
