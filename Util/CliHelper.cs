using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Util;
public class CliHelper
{
    public static void PrintEpisodes(EpisodeResponse episodes)
    {
        foreach(Episode episode in episodes.Results)
        {
            Console.WriteLine($"Episode {episode.Id}\nName: {episode.Name}\n");
        }
    }
}