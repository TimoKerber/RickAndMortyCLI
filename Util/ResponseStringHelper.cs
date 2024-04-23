namespace RickAndMortyCLI.Util;

public class ResponseStringHelper
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
}