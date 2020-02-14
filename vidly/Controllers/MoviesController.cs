using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

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

        [Route("Movies/Create")]
        public ActionResult Create()
        {
            var genres = _context.genreTypes.ToList();
            var movieModel = new movieFormModel { genreTypes = genres };
            return View(movieModel);
        }
        public ActionResult Save(Movie movie)
        {
            _context.movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
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
            var movieSelected = _context.movies.Include("genreType").SingleOrDefault(item => item.Id == id);
            var genres = _context.genreTypes.ToList();
            var movieModel = new movieFormModel {
                                    genreTypes = genres,
                                    movie = movieSelected
                                };
            if (movie != null)
                return View("Create", movieModel);
            return HttpNotFound();

        }
    }
}