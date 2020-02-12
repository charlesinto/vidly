using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using vidly.ViewModel;

namespace vidly.Models
{
    
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Movie> movie { get; set; }
        public DbSet<Rental> rental { get; set; }

        public MyDbContext() { }
    }
}