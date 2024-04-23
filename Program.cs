using RickAndMortyCLI.Service;

namespace RickAndMortyCLI;
public class Program()
{
    public static async Task Main(string[] args)
    {
        RickAndMortyService service = new();
        
        var response = await service.GetAllEpisodesAsync();
        Console.WriteLine(response);
    }
}