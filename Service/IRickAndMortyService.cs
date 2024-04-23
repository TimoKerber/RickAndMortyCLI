using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Service;

public interface IRickAndMortyService
{
    /// <summary>
    /// requests all episodes of rick and morty
    /// </summary>
    /// <returns>List of all Episodes</returns>
    Task<EpisodeResponse?> GetAllEpisodesAsync();
    /// <summary>
    /// requests the next page for a prior request
    /// </summary>
    /// <param name="page">page number for next request</param>
    /// <returns></returns>
    Task<List<Episode>?> GetEpisodePageAsync(string httpRequest);
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