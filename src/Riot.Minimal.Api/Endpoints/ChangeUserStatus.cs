using Riot.Minimal.Api.Persistence;
using Riot.Minimal.Api.Persistence.Entities;

namespace Riot.Minimal.Api.Endpoints;

public static class ChangeUserStatus
{
    public static void MapUpdateStatus(this WebApplication app)
    {
        app.MapPut("/{id}/-change-status", async (int id, UpdateUserStatusModel model, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var user = await db.Users.FindAsync(id, cancellationToken);
            if (user is null) return Results.BadRequest();

            user.Status = model.Status;

            await db.SaveChangesAsync(cancellationToken);
            return Results.NoContent();
        });
    }
}

public sealed record UpdateUserStatusModel(StatusEnumType Status);