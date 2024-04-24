using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Util;

public class StringHelper
{
    /// <summary>
    /// creates the request string for requesting multiple objects by id
    /// </summary>
    /// <param name="baseString"></param>
    /// <param name="route"></param>
    /// <param name="ids"></param>
    /// <returns></returns>
    public static string GetStringForMultipleRequest(Uri baseUri, string route,  int[] ids)
    {
        string getRequest = $"{baseUri}{route}";
        if(ids.Length == 0) return getRequest;
        foreach(int id in ids)
        {
            if (id != ids.Last())
            {
                getRequest += $"/{id},";
            }
            else 
            {
                getRequest += $"/{id}";
            }
        }
        return getRequest;
    }

    /// <summary>
    /// splits the id of all characters of an episode
    /// </summary>
    /// <param name="characterRequests">request strings for all characters of an episode</param>
    /// <returns> array of character IDs</returns>
    public static int[] GetCharacterIds(List<string>? characterRequests)
    {
        if (characterRequests == null) return [];
        int[] ids = new int[characterRequests.Count];
        for(int index = 0; index < characterRequests.Count; index++)
        {
            ids[index] = int.Parse(characterRequests[index].Split("/").Last());
        }
        return ids;
    }

    /// <summary>
    /// prepares a list of character names for command line output
    /// </summary>
    /// <param name="characters"></param>
    /// <returns></returns>
    public static List<string> GetCharacterNames(List<Character>? characters)
    {
        List<string> characterNames = [];
        if(characters == null) return characterNames;
        foreach(Character character in characters)
        {
            if(character.Name != null)
            {
                characterNames.Add(character.Name);
            }
        }
        return characterNames;
    }
}