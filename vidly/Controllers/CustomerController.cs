using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using vidly.Models;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>();
        private MyDbContext _context;
        public CustomerController()
        {
            _context = new MyDbContext();
            //initializeCustomers();
        }
        // GET: Customer
        [Route("customers")]
        public ActionResult Index()
        {
            var customers = _context.customers.Include(c => c.membershipType).ToList();
            return View(customers);
        }
        [Route("customers/edit/{id}")]
        public ActionResult GetCustomer(int id)
        {
            //var found = false;
            var customer = _context.customers.SingleOrDefault(item => item.Id == id);
            //var selectedCustomer = new Customer();
            //foreach(var customer in customers)
            //{
            //    if(customer.Id == id)
            //    {
            //        found = true;
            //        selectedCustomer = customer;
            //    }
            //}
            if (customer != null)
                return View(customer);
            return HttpNotFound();
        }
        private void initializeCustomers()
        {
            customers.Add(new Customer(1, "Charles"));
            customers.Add(new Customer(2, "Lina Onuorah"));
            customers.Add(new Customer(3, "Ugonma Onuorah"));
            customers.Add(new Customer(4, "Chioma Odoguw okeson"));
        }
    }
}