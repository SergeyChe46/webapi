﻿using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Repository;

namespace webapi;
[Route("[controller]/{action}")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IRepository _movieRepo;
    public HomeController(IRepository movieRepo)
    {
        _movieRepo = movieRepo;
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
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        if (movie == null)
            return BadRequest(ModelState);
        

        if (_movieRepo.CreateMovie(movie))
        {
            ModelState.AddModelError("", $"Something went wrong while saving movie record of {movie.Title}");
            return StatusCode(500, ModelState);
        }

        return Ok(movie);

    }

    /// <summary>
    /// Update a movie
    /// </summary>
    /// <return></return>
    [HttpPut("{movieId:int}")]
    public IActionResult Update(int movieId, [FromBody] Movie movie)
    {
        if (movie == null || movieId != movie.Id)
            return BadRequest(ModelState);

        if (!_movieRepo.UpdateMovie(movie))
        {
            ModelState.AddModelError("", $"Something went wrong while updating movie : {movie.Title}");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    /// <summary>
    /// Update a movie
    /// </summary>
    /// <return></return>
    [HttpDelete("{movieId:int}")]
    public IActionResult Delete(int movieId)
    {
        if (!_movieRepo.MovieExists(movieId))
        {
            return NotFound();
        }

        var movieobj = _movieRepo.GetMovie(movieId);

        if (!_movieRepo.DeleteMovie(movieobj))
        {
            ModelState.AddModelError("", $"Something went wrong while deleting movie : {movieobj.Title}");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
}
