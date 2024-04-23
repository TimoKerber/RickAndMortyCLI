using RickAndMortyCLI.Model;

namespace RickAndMortyCLI.Service;

public interface IRickAndMortyService
{
    /// <summary>
    /// requests all episodes of rick and morty
    /// </summary>
    /// <returns>List of all Episodes</returns>
    Task<EpisodeResponse?> GetAllEpisodesAsync();
}