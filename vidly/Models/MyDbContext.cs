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
        public DbSet<Movie> movies { get; set; }
        public DbSet<Rental> rentals { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }

        public DbSet<GenreType> genreTypes { get; set; }

        public MyDbContext() { }
    }
}