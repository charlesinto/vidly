using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class RentalController : Controller
    {
        private List<Rental> rental = new List<Rental>();
        public RentalController()
        {
            
        }
        // GET: Rental
        [Route("rentals")]
        public ActionResult Index()
        {
            return View(rental);
        }
    }
}