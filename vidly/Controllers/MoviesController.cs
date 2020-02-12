using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movie = new List<Movie>();
        public MoviesController()
        {
            movie.Add(new Movie(1, "Shrek"));
            movie.Add(new Movie(2, "Frozen"));
            movie.Add(new Movie(3, "X-Men"));
            movie.Add(new Movie(4, "Birds of Prey"));
            movie.Add(new Movie(5, "King of Boys"));
        }
        [Route("movies")]
        public ActionResult Index()
        {
            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name="Shrek" };
            return View(movie);
        }
        public ActionResult GameRelease(int? year, string sortBy)
        {
            if (!year.HasValue)
                year = 2000;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("We are searching {0} by sort {1}", year, sortBy));
        }
        [Route("movie/edit/{id}")]
        public ActionResult getMovie(int id)
        {
            var found = false;
            var selectedMovie = new Movie();
            foreach (var mov in movie)
            {
                if (mov.Id == id)
                {
                    found = true;
                    selectedMovie = mov;
                }
            }
            if (found)
                return View(selectedMovie);
            return HttpNotFound();

        }
    }
}