using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Service;

public interface IRickAndMortyService
{
    /// <summary>
    /// requests the first page of episodes
    /// </summary>
    /// <param name="page">page number for next request</param>
    /// <returns></returns>
    Task<List<Episode>?> GetEpisodePageAsync();
    /// <summary>
    /// requests info for a single character
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Character?> GetCharacterAsync(int id);
    /// <summary>
    /// requests info for multiple characters
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<List<Character>?> GetMultipleCharactersAsync(int[] ids);
}