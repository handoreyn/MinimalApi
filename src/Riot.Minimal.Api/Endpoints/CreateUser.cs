using Riot.Minimal.Api.Persistence;
using Riot.Minimal.Api.Persistence.Entities;

namespace Riot.Minimal.Api.Endpoints;

public static class CreateUser
{
    public static void MapPostUser(this WebApplication app)
    {
        app.MapPost("/", async (User user, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            await db.AddAsync(user, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return Results.Created($"/{user.Id}", user);
        });
    }
}