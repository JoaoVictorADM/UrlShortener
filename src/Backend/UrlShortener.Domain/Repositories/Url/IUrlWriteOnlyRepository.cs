namespace UrlShortener.Domain.Repositories.Url;

public interface IUrlWriteOnlyRepository
{
    Task InsertAsync(Entities.Url url);
}
