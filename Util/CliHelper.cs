using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Util;
public class CliHelper
{
    public static void PrintEpisodes(List<Episode> episodes)
    {
        if(episodes == null || episodes.Count == 0)
        {
            Console.WriteLine("No episodes available");
            return ;
        }
        foreach(Episode episode in episodes)
        {
            Console.WriteLine($"Episode {episode.Id}\nName: {episode.Name}\n");
        }
    }
}