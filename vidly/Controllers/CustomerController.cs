using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

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
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            var _customer = _context.customers.Include(c => c.membershipType).SingleOrDefault(item => item.Id == id);
            if (_customer != null)
            {
                var membershipType = _context.membershipTypes.ToList();
                var customerFormModel = new CustomerFormModel { customer = _customer, membershipTypes = membershipType };
                return View("New", customerFormModel);
            }             
            return HttpNotFound();
        }
        [Route("customer/new")]
        public ActionResult New()
        {
            var memeberShipType = _context.membershipTypes.ToList();
            var customerFormModel = new CustomerFormModel{ membershipTypes = memeberShipType };
            return View(customerFormModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if(customer.Id == 0)
            {
                _context.customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.customers.Single(cust => cust.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.birthdate = customer.birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}