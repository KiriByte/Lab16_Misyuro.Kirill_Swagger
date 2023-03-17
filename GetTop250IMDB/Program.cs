// See https://aka.ms/new-console-template for more information

using RestSharp;
using RestSharp.Serializers.Json;

string pathToFile = @"../../../../films.json";

var client = new RestClient(baseUrl: "https://imdb-api.com/",
    configureSerialization: s => s.UseSystemTextJson());

var request = new RestRequest("en/API/Top250Movies/k_ui63shvj");
var response = await client.GetAsync(request);

File.WriteAllText(pathToFile, response.Content);