using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Persistence.Entities;

namespace Riot.Minimal.Api.Persistence;

public sealed class RiotDatabaseContext : DbContext
{
    public RiotDatabaseContext(DbContextOptions<RiotDatabaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}