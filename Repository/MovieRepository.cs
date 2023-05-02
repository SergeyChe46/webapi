using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppDbContext _dbContext;

        public MovieRepository(MovieAppDbContext db)
        {
            _dbContext = db;
        }
        public async Task CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task UpdateMovie(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> MovieExists(int id)
        {
            return await _dbContext.Movies.AnyAsync(x => x.Id == id);
        }

        public async Task<Movie?> GetMovie(string title)
        {
            return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Title == title);
        }
    }
}
