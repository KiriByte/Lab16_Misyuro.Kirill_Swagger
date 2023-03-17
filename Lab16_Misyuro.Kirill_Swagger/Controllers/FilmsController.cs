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

    [HttpGet]
    [Route("GetAllFilms")]
    public List<FilmDetail?> GetAllFilms()
    {
        return _service.Films;
    }

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

    [HttpPost]
    [Route("AddFilm")]
    public IActionResult AddFilm(FilmDetail film)
    {
        _service.Films.Add(film);
        _service.Serialize();
        return Ok(film);
    }

    [HttpPut]
    [Route("UpdateFilm/{id}")]
    public IActionResult UpdateFilm(string id, FilmDetail film)
    {
        var foundFilm = _service.Films.Find(p => p?.Rank == id);
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