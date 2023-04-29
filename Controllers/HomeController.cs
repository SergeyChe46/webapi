using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using webapi.MappingConfiguration;
using webapi.Models;
using webapi.Repository;

namespace webapi;
[Route("[controller]/{action}")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IRepository _movieRepo;
    private readonly Logger logger;
    public HomeController(IRepository movieRepo)
    {
        _movieRepo = movieRepo;
        logger = LogManager.GetCurrentClassLogger();
    }

    /// <summary>
    /// Get list of all Movies
    /// </summary>
    [HttpGet]
    public IQueryable? Get()
    {
        return _movieRepo.GetMovies() as IQueryable;
    }

    /// <summary>
    /// Create a new movie
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MovieViewModel movie)
    {
        var mapper = MovieMapping.IntializeMovieMapper();
        
        if (movie == null)
        {
            logger.Warn($"Warn was at {DateTime.Now} with try to add {movie}");
            return BadRequest(ModelState);
        }
        
        var movieDTO = mapper.Map<Movie>(movie);

        await _movieRepo.CreateMovie(movieDTO);

        logger.Info($"{movieDTO} was added successfully");
        return Ok(movieDTO);
    }

    /// <summary>
    /// Update a movie
    /// </summary>
    /// <return></return>
    [HttpPut("{movieId:int}")]
    public IActionResult Update(int movieId, [FromBody] MovieViewModel movie)
    {
        var mapper = MovieMapping.IntializeMovieMapper();
        var movieDTO = mapper.Map<Movie>(movie);
        _movieRepo.UpdateMovie(movieDTO);

        logger.Info($"{movieDTO} was update successfully");
        return Ok(movieDTO);
    }

    /// <summary>
    /// Update a movie
    /// </summary>
    /// <return></return>
    [HttpDelete("{title:alpha}")]
    public async Task<IActionResult> Delete(string title, int id)
    {
        if (!(await _movieRepo.MovieExists(id)))
        {
            logger.Warn($"Movie with id - {id}, and title - {title} not found");
            return NotFound();
        }

        var movieobj = await _movieRepo.GetMovie(title);
        if(movieobj != null)
        {
            await _movieRepo.DeleteMovie(movieobj);
            logger.Info($"Movie {movieobj.Id} deleted");
            return Ok();
        }
        return NoContent();
    }
}
