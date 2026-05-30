using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.DataAccess;

public class UrlShortenerDbContext : DbContext
{
    public UrlShortenerDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Url> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlShortenerDbContext).Assembly);
    }
}
