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
    public async Task<List<Episode>?> GetAllEpisodesAsync(string httpRequest = "https://rickandmortyapi.com/api/episode")
    {
        try
        {
            var response = await client.GetAsync(httpRequest);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var episodeResponse = JsonConvert.DeserializeObject<EpisodeResponse>(content) ?? throw new NullReferenceException();
            var episodeList = episodeResponse.Results;

            int pages = episodeResponse.Info.Pages;
            int currentPage = 2;
            while(currentPage <= pages)
            {
                episodeList.AddRange(await GetEpisodePageAsync($"{client.BaseAddress}/episode?page={currentPage}"));
                currentPage++;
            }
            return episodeList;
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
            string getRequest = StringHelper.GetMultiple(client.BaseAddress, "character", ids);
            var response = await client.GetAsync(getRequest);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var characterResponse = JsonConvert.DeserializeObject<List<Character>>(content) ?? throw new NullReferenceException();
            return characterResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<List<Episode>?> GetEpisodePageAsync(string request)
    {
        try
        {
            var response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var episodeResponse =  JsonConvert.DeserializeObject<EpisodeResponse>(content) ?? throw new NullReferenceException();
            return episodeResponse.Results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }
}