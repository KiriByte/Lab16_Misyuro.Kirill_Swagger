using Lab16_Misyuro.Kirill_Swagger.Models;
using Lab16_Misyuro.Kirill_Swagger.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab16_Misyuro.Kirill_Swagger.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController : Controller
{
    private readonly FilmsService _service;

    public FilmsController(FilmsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get all films from list
    /// </summary>
    /// <remarks>This method doesnt take any parameters, because it print all list of films</remarks>
    [HttpGet]
    [Route("GetAllFilms")]
    public List<FilmDetail?> GetAllFilms()
    {
        return _service.Films;
    }

    /// <summary>
    /// Get film from list by id
    /// </summary>
    /// <remarks>This method search film from list by id and print it.If film not found, return error 404.</remarks>
    /// <response code="200">Film found</response>
    /// <response code="404">Film not found</response>
    [HttpGet]
    [Route("GetById/{id}")]
    public IActionResult GetById(string id)
    {
        var foundFilm = _service.Films.Find(p => p?.Id == id);
        if (foundFilm != null)
        {
            return Ok(foundFilm);
        }

        return NotFound();
    }

    /// <summary>
    /// Get film from list by rank
    /// </summary>
    /// <remarks>This method search film from list by rank and print it.If film not found, return error 404.</remarks>
    /// <response code="200">Film found</response>
    /// <response code="404">Film not found</response>
    [HttpGet]
    [Route("GetByRank/{rank}")]
    public IActionResult GetByRank(string rank)
    {
        var foundFilm = _service.Films.Find(p => p?.Rank == rank);
        if (foundFilm != null)
        {
            return Ok(foundFilm);
        }

        return NotFound();
    }

    /// <summary>
    /// Add film to list
    /// </summary>
    /// <remarks>This method add film to the list. At the moment there is no check for the uniqueness of the id.</remarks>
    [HttpPost]
    [Route("AddFilm")]
    public IActionResult AddFilm(FilmDetail film)
    {
        _service.Films.Add(film);
        _service.Serialize();
        return Ok(film);
    }

    /// <summary>
    /// Update film from list by id
    /// </summary>
    /// <remarks>This method update film from list by id.If film not found, return error 404.</remarks>
    /// <response code="200">Film updated</response>
    /// <response code="404">Film not found</response>
    [HttpPut]
    [Route("UpdateFilm/{id}")]
    public IActionResult UpdateFilm(string id, FilmDetail film)
    {
        var foundFilm = _service.Films.Find(p => p?.Id == id);
        if (foundFilm != null)
        {
            foundFilm.Id = film.Id;
            foundFilm.Rank = film.Rank;
            foundFilm.Crew = film.Crew;
            foundFilm.Year = film.Year;
            foundFilm.Image = film.Image;
            foundFilm.Title = film.Title;
            foundFilm.FullTitle = film.FullTitle;
            foundFilm.IMDbRating = film.IMDbRating;
            foundFilm.IMDbRatingCount = film.IMDbRatingCount;

            _service.Serialize();
            return Ok(film);
        }

        return NotFound();
    }

    /// <summary>
    /// Delete film from list by id
    /// </summary>
    /// <remarks>This method delete film from list by id.If film not found, return error 404.</remarks>
    /// <response code="200">Film deleted</response>
    /// <response code="404">Film not found</response>
    [HttpDelete]
    [Route("DeleteFilm/{id}")]
    public IActionResult DeleteFilm(string id)
    {
        var foundFilm = _service.Films.Find(p => p?.Id == id);
        if (foundFilm != null)
        {
            _service.Films.Remove(foundFilm);
            _service.Serialize();
            return Ok(_service.Films);
        }

        return NotFound();
    }
}