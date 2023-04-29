using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Repository
{
    public class MovieRepository : IRepository
    {
        private readonly MovieAppDbContext _db;

        public MovieRepository(MovieAppDbContext db)
        {
            _db = db;
        }
        public async Task CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }

        public async Task<IQueryable<Movie>> GetMovies()
        {
            return _db.Movies.AsQueryable();
        }

        public async Task UpdateMovie(Movie movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> MovieExists(int id)
        {
            return await _db.Movies.AnyAsync(x => x.Id == id);
        }

        public async Task<Movie?> GetMovie(string title)
        {
            return await _db.Movies.FirstOrDefaultAsync(m => m.Title == title);
        }
    }
}
