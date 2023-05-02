using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webapi.Models;

namespace webapi.Repository
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
