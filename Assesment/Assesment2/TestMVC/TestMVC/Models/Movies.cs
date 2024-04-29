using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
 
        public class Movie
        {
            public int Mid { get; set; }

    
            public string Moviename { get; set; }

          
            public DateTime DateofRelease { get; set; }
        
    }
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("name=MoviesDBConnectionString")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }

}