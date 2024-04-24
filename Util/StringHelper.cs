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
    public static string GetMultiple(Uri baseUri, string route,  int[] ids)
    {
        string getRequest = $"{baseUri}{route}/";
        foreach(int id in ids)
        {
            if (id != ids.Last())
                getRequest += $"{id},";
            else 
                getRequest += $"{id}";
        }
        return getRequest;
    }
    /// <summary>
    /// splits the id of all characters of an episode
    /// </summary>
    /// <param name="characterRequests">request strings for all characters of an episode</param>
    /// <returns> array of character IDs</returns>
    public static int[] GetCharacterIds(List<string> characterRequests)
    {
        int i = 0;
        int[] ids = new int[characterRequests.Count];
        foreach(string characterRequest in characterRequests)
        {
            ids[i] = int.Parse(characterRequest.Split("/").Last());
            i++;
        }
        return ids;
    }
}