using Riot.Minimal.Api.Persistence;

namespace Riot.Minimal.Api.Endpoints;

public static class DeleteUser
{
    public static void MapDeleteUser(this WebApplication application)
    {
        application.MapDelete("/{id}", async (int id, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var user = await db.Users.FindAsync(id, cancellationToken);
            if (user is null) return Results.BadRequest();

            db.Remove(user);
            await db.SaveChangesAsync(cancellationToken);

            return Results.NoContent();
        });
    }
}