using RickAndMortyCLI.Service;
using RickAndMortyCLI.Util;

namespace RickAndMortyCLI;
public class Program()
{
    public static async Task Main(string[] args)
    {
        RickAndMortyService service = new();
        var episodes = await service.GetAllEpisodesAsync();
        CliHelper.PrintEpisodes(episodes);
    }
}