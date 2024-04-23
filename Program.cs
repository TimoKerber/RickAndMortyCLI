using RickAndMortyCLI.Service;
using RickAndMortyCLI.Util;

namespace RickAndMortyCLI;
public class Program()
{
    public static async Task Main(string[] args)
    {
        RickAndMortyService service = new();
        var character = await service.GetMultipleCharactersAsync([1, 2, 3]);
    }
}