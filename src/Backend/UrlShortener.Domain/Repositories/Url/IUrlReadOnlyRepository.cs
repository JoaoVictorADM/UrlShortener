namespace UrlShortener.Domain.Repositories.Url;

public interface IUrlReadOnlyRepository
{
    Task<Entities.Url?> GetByShortCodeAsync(string shortCode);
}
