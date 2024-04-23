using Newtonsoft.Json;
using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Service;

public class RickAndMortyService : IRickAndMortyService
{
    private readonly HttpClient client;

    public RickAndMortyService()
    {
        client = new()
        {
            BaseAddress = new Uri("https://rickandmortyapi.com/api/")
        };
    }
    public async Task<EpisodeResponse?> GetAllEpisodesAsync()
    {
        var response = await client.GetAsync($"{client.BaseAddress}/episode");
        //throws exception, so need to handle it in the main method
        response.EnsureSuccessStatusCode();
        var contentString = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<EpisodeResponse>(contentString);
        return data;
    }
}