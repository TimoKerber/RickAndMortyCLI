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
        try
        {
            var response = await client.GetAsync($"{client.BaseAddress}/episode");
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            var episodeResp = JsonConvert.DeserializeObject<EpisodeResponse>(contentString);
            return episodeResp;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<EpisodeResponse?> GetPageAsync(string httpRequest)
    {
        try
        {
            var response = await client.GetAsync(httpRequest);
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EpisodeResponse>(contentString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
}