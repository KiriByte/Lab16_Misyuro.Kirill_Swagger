using Lab16_Misyuro.Kirill_Swagger.Service;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "Lab16_Misyuro.Kirill_Swagger.xml");
    options.IncludeXmlComments(xmlPath);
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Top 250 Films API",
        Description = @"Project GetTop250IMDB takes a list of top 250 movies by IMDB rating.
This API uses this list and performs CRUD operations.",
        Contact = new OpenApiContact
        {
            Name = "Kirill Misyuro",
            Url = new Uri("https://github.com/KiriByte")
        },
    });
});


builder.Services.AddTransient<FilmsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();