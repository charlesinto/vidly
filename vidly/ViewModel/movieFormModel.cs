using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModel
{
    public class movieFormModel
    {
        public Movie movie;
        public IEnumerable<GenreType> genreTypes;
    }
}