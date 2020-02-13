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

        private MyDbContext _context;
        public MoviesController()
        {
            _context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("movies")]
        public ActionResult Index()
        {
            var movie = _context.movies.Include("GenreType").ToList();
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
            var movie = _context.movies.Include("genreType").SingleOrDefault(item => item.Id == id);
            
            if (movie != null)
                return View(movie);
            return HttpNotFound();

        }
    }
}