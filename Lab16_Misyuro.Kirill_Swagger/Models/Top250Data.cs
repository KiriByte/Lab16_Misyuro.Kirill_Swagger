using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab16_Misyuro.Kirill_Swagger.Models;

public class Top250Data
{
    public List<FilmDetail?> Items { get; set; }
    public string ErrorMessage { get; set; }

    public Top250Data()
    {
        ErrorMessage = string.Empty;
        Items = new List<FilmDetail?>();
    }

    public Top250Data(string errorMessage)
    {
        ErrorMessage = errorMessage;
        Items = new List<FilmDetail?>();
    }
    
    
}