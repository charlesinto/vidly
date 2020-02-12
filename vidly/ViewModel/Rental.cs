using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModel
{
    public class Rental
    {
        public int Id { get; set; }
        private List<Customer> _customer { get; set; }
        private Movie _movie { get; set; }

        public List<Customer> customer
        {
            get
            {
                return _customer;
            }
        }
        public Movie movie
        {
            get
            {
                return _movie;
            }
        }

        public  Rental(List<Customer> customer, Movie movie)
        {
            _customer = customer;
            _movie = movie;
        }
        public List<Customer> getCustomer()
        {
            return _customer;
        }
        public Movie getMovie()
        {
            return _movie;
        }
        public void updateCustomerName(int id, string customerName)
        {
            foreach(var customer in _customer)
            {
                if(customer.Id == id)
                {
                    customer.Name = customerName;
                }
            }
                
        }
        public void updateMovieName(string movieName)
        {
            _movie.Name = movieName;
        }
    }
}