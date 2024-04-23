using Newtonsoft.Json;
using RickAndMortyCLI.Model;
using RickAndMortyCLI.Util;

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
            var content = await response.Content.ReadAsStringAsync();
            var episodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(content);
            return episodeResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<Character?> GetCharacterAsync(int id)
    {
        try
        {
            var response = await client.GetAsync($"{client.BaseAddress}/character/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var characterResp = JsonConvert.DeserializeObject<Character>(content);
            return characterResp;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<List<Character>?> GetMultipleCharactersAsync(int[] ids)
    {
        try
        {
            if(client.BaseAddress == null) throw new NullReferenceException();
            string getRequest = ResponseStringHelper.GetMultiple(client.BaseAddress, "character", ids);
            var response = await client.GetAsync(getRequest);
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            var characterResponse = JsonConvert.DeserializeObject<List<Character>>(contentString) ?? throw new NullReferenceException();
            return characterResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<List<Episode>?> GetEpisodePageAsync(string httpRequest)
    {
        try
        {
            var response = await client.GetAsync(httpRequest);
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            var episodeResponse =  JsonConvert.DeserializeObject<EpisodeResponse>(contentString) ?? throw new NullReferenceException();
            return episodeResponse.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
}