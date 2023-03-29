using Lab16_Misyuro.Kirill_Swagger.Models;
using Newtonsoft.Json;

namespace Lab16_Misyuro.Kirill_Swagger.Service;

public class FilmsService
{
    public string _pathToFile = @"../films.json";
    public List<FilmDetail?> Films { get; set; }

    public FilmsService()
    {
        string json = ReadFileToString();
        Films = JsonConvert.DeserializeObject<Top250Data>(json).Items;
    }

    private string ReadFileToString()
    {
        if (!File.Exists(_pathToFile))
        {
            return "";
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