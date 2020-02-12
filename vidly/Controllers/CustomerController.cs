using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>();
        public CustomerController()
        {
            customers.Add(new Customer(1, "Charles"));
            customers.Add(new Customer(2, "Lina Onuorah"));
            customers.Add(new Customer(3, "Ugonma Onuorah"));
            customers.Add(new Customer(4, "Chioma Odoguw okeson"));
        }
        // GET: Customer
        [Route("customers")]
        public ActionResult Index()
        {
            
            return View(customers);
        }
        [Route("customers/edit/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var found = false;
            var selectedCustomer = new Customer();
            foreach(var customer in customers)
            {
                if(customer.Id == id)
                {
                    found = true;
                    selectedCustomer = customer;
                }
            }
            if (found)
                return View(selectedCustomer);
            return HttpNotFound();
        }
    }
}