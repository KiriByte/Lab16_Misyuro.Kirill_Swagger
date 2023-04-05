using Lab16_Misyuro.Kirill_Swagger.Controllers;
using Lab16_Misyuro.Kirill_Swagger.Models;
using Lab16_Misyuro.Kirill_Swagger.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject1;

public class UnitTest1
{
    private string stringJson => File.ReadAllText("../../../../films.json");

    [Fact]
    public void GetAllFilms_PositiveTesting_ShouldReturnNotEmptyListFilms()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.GetAllFilms();
        // Assert
        Assert.NotEmpty(res);
    }

    [Fact]
    public void GetById_PositiveTesting_ShouldRetrunOkWithFilmById()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.GetById("tt0068646");
        // Assert
        Assert.IsType<OkObjectResult>(res);
    }

    [Fact]
    public void GetById_NegativeTesting_NotFoundFilmById()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.GetById("1");
        // Assert
        Assert.IsType<NotFoundResult>(res);
    }

    [Fact]
    public void GetByRank_PositiveTesting_ShouldRetrunOkWithFilmByRank()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.GetByRank("1");
        // Assert
        Assert.IsType<OkObjectResult>(res);
    }

    [Fact]
    public void GetByRank_NegativeTesting_NotFoundFilmByRank()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.GetByRank("511");
        // Assert
        Assert.IsType<NotFoundResult>(res);
    }

    [Fact]
    public void AddFilm_PositiveTesting_ShouldRetrunOkWithAddedFilm()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        var film = new FilmDetail();
        film.Id = "1000";
        film.Rank = "1000";
        film.Title = "test";
        film.FullTitle = "test";
        film.Year = "test";
        film.Image = "test";
        film.Crew = "test";
        film.IMDbRating = "test";
        film.IMDbRatingCount = "test";
        // Act
        var res = contactsController.AddFilm(film);
        // Assert
        Assert.IsType<OkObjectResult>(res);
    }
    
    [Fact]
    public void UpdateFilm_PositiveTesting_ShouldRetrunOkWithUpdatedFilm()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        var film = new FilmDetail();
        film.Id = "1000";
        film.Rank = "1000";
        film.Title = "test";
        film.FullTitle = "test";
        film.Year = "test";
        film.Image = "test";
        film.Crew = "test";
        film.IMDbRating = "test";
        film.IMDbRatingCount = "test";
        // Act
        var res = contactsController.UpdateFilm("tt0068646",film);
        // Assert
        Assert.IsType<OkObjectResult>(res);
    }
    [Fact]
    public void UpdateFilm_NegativeTesting_ShouldRetrunNotFound()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        var film = new FilmDetail();
        film.Id = "1000";
        film.Rank = "1000";
        film.Title = "test";
        film.FullTitle = "test";
        film.Year = "test";
        film.Image = "test";
        film.Crew = "test";
        film.IMDbRating = "test";
        film.IMDbRatingCount = "test";
        // Act
        var res = contactsController.UpdateFilm("1",film);
        // Assert
        Assert.IsType<NotFoundResult>(res);
    }
    
    [Fact]
    public void DeleteFilm_PositiveTesting_ShouldRetrunOk()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.DeleteFilm("tt0068646");
        // Assert
        Assert.IsType<OkObjectResult>(res);
    }
    
    [Fact]
    public void DeleteFilm_PositiveTesting_ShouldRetrunNotFound()
    {
        // Arrange
        var mock = new Mock<FilmsService>();
        mock.Setup(x => x.ReadFileToString()).Returns(stringJson);
        var contactsController = new FilmsController(mock.Object);
        // Act
        var res = contactsController.DeleteFilm("1");
        // Assert
        Assert.IsType<NotFoundResult>(res);
    }
}