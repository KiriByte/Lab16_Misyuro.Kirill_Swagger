using Lab16_Misyuro.Kirill_Swagger.Models;
using Newtonsoft.Json;

namespace Lab16_Misyuro.Kirill_Swagger.Service;

public class FilmsService
{
    private readonly string _pathToFile = @"../films.json";
    public List<FilmDetail?> Films { get; set; }

    public FilmsService()
    {
        string json = ReadFileToString();
        Films = JsonConvert.DeserializeObject<Top250Data>(json).Items;
    }

    public bool UpdateFilm(string id, FilmDetail film)
    {
        var foundFilm = Films.Find(p => p?.Rank == id);
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
            
            Serialize();
            return true;
        }

        return false;
    }

    private string ReadFileToString()
    {
        if (!File.Exists(_pathToFile))
        {
            File.WriteAllText(_pathToFile, "");
        }

        return File.ReadAllText(_pathToFile);
    }

    public void Serialize()
    {
        var data = new Top250Data
        {
            Items = Films
        };
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(_pathToFile, json);
    }
}