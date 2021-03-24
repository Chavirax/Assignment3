using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext (DbContextOptions<MovieListContext> options) :base (options)
        {

        }

        public DbSet<MovieItem> Movie { get; set; }
    }
}
