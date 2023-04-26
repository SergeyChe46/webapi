using webapi.Models;

namespace webapi.Repository
{
    public interface IRepository
    {
        IQueryable<Movie> GetMovies();

        Movie GetMovie(int id);

        bool MovieExists(int id);

        bool MovieExists(string title);

        bool CreateMovie(Movie movie);

        bool UpdateMovie(Movie movie);

        bool DeleteMovie(Movie movie);

        bool Save();
    }
}
