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
    /// gets the next page for a prior request
    /// </summary>
    /// <param name="page">page number for next request</param>
    /// <returns></returns>
    Task<EpisodeResponse?> GetPageAsync(string baseString);
}