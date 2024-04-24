using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Util;
public class CliHelper
{
    public static void PrintEpisode(Episode episode, List<string> characterNames)
    {
        if(episode == null)
        {
            Console.WriteLine("No episodes available");
            return ;
        }
        string output = $"Episode {episode.Id}\nName: {episode.Name}\nCharacters: ";
        foreach(string characterName in characterNames)
        {
            if (characterName != characterNames.Last())
            {
                output += $"{characterName}, ";
            }
            else
            {
                output += $"{characterName}.\n";
            }
        }
        Console.WriteLine(output);
    }
}