using RickAndMortyCLI.Service;
using RickAndMortyCLI.Util;

namespace RickAndMortyCLI;
public class Program()
{
    public static async Task Main(string[] args)
    {
        RickAndMortyService service = new();
        
        var response = await service.GetAllEpisodesAsync();

        while(response != null && response.Info != null && response.Info.Next != null)
        {
            CliHelper.PrintEpisodes(response);
            response = await service.GetPageAsync(response.Info.Next);
        }
    }
}