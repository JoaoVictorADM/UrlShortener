namespace UrlShortener.Domain.Repositories;

public interface IUnitOfWork
{
    public Task Commit();
}
