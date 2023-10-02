using Riot.Minimal.Api.Persistence;
using Riot.Minimal.Api.Persistence.Entities;

namespace Riot.Minimal.Api.Endpoints;

public static class PutUser
{
    public static void MapPutUser(this WebApplication app)
    {
        app.MapPut("/{id}", async (int id, User user, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var existingUser = await db.Users.FindAsync(id, cancellationToken);
            if (existingUser is null) return Results.BadRequest();

            existingUser.Email = user.Email;
            existingUser.Username = user.Username;

            await db.SaveChangesAsync(cancellationToken);
            return Results.NoContent();
        });
    }
}