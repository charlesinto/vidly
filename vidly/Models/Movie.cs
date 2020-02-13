using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Movie
    {
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public GenreType genreType { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public int genreTypeId { get; set; }

        public Movie() { }
        

    }
}