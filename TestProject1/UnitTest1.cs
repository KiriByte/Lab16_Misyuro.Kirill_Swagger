using Lab16_Misyuro.Kirill_Swagger.Controllers;
using Lab16_Misyuro.Kirill_Swagger.Models;
using Lab16_Misyuro.Kirill_Swagger.Service;
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
    
}