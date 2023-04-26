using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webapi.Models;

namespace webapi.Repository
{
    public class MovieAppDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public MovieAppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
