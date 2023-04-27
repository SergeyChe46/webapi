using webapi.Models;

namespace webapi.Repository
{
    public interface IRepository
    {
        Task<IQueryable<Movie>> GetMovies();

        Task<Movie> GetMovie(string title);

        Task<bool> MovieExists(int id);

        Task CreateMovie(Movie movie);

        Task UpdateMovie(Movie movie);

        Task DeleteMovie(Movie movie);
    }
}
