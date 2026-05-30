using UrlShortener.Domain.Repositories;

namespace UrlShortener.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly UrlShortenerDbContext _dbContext;

    public UnitOfWork(UrlShortenerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
