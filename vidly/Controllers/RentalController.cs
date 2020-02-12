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
            rental.Add(new Rental(new List<Customer> { 
            new Customer(1, "Busola Dakore"),
            new Customer(2, "Lina Ekeh"),
            new Customer(3, "Ugonma Amah")}, new Movie(1, "Shrek")));
        }
        // GET: Rental
        [Route("rentals")]
        public ActionResult Index()
        {
            return View(rental);
        }
    }
}