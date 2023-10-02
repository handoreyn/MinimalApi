using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Persistence;

namespace Riot.Minimal.Api.Endpoints;

public static class GetUserByUserId
{
    public static void MapUserById(this WebApplication app)
    {
        app.MapGet("/{id}", async (int id, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (user is null) return Results.NotFound();

            return Results.Ok(user);
        });
    }
}