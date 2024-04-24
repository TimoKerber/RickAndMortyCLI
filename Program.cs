using RickAndMortyCLI.Service;
using RickAndMortyCLI.Util;
using RickAndMortyCLI.Model;

namespace RickAndMortyCLI;
public class Program()
{
    public static async Task Main(string[] args)
    {
        RickAndMortyService service = new();
        var episodes = await service.GetEpisodePageAsync();
        if (episodes != null)
        {
            foreach(Episode episode in episodes)
            {
                //get characters as strings
                int[] characterIds = StringHelper.GetCharacterIds(episode.Characters);
                var characters = await service.GetMultipleCharactersAsync(characterIds);
                List<string> characterNames = StringHelper.GetCharacterNames(characters); 
                CliHelper.PrintEpisodes(episode, characterNames);
            }
        }
    }
}