using Cassandra.Mapping;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Repositories.Url;

namespace UrlShortener.Infrastructure.DataAccess.Repositories;

public class UrlRepository : IUrlReadOnlyRepository, IUrlWriteOnlyRepository
{
    private readonly IMapper _mapper;

    public UrlRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Url?> GetByShortCodeAsync(string shortCode)
    {
        return await _mapper.SingleOrDefaultAsync<Url>(
            "WHERE short_code = ?", shortCode);
    }

    public async Task InsertAsync(Url url)
    {
        await _mapper.InsertAsync(url);
    }

}
