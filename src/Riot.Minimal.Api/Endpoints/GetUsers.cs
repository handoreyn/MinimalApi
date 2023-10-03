using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Persistence;

namespace Riot.Minimal.Api.Endpoints;

public static class GetUsersEndpoint
{
    public static void MapGetUsers(this WebApplication app)
    {
        app.MapGet("/", async (RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var users = await db.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (!users.Any()) return Results.NotFound(new ErrorResponseModel("There is no user exist on system."));
            return Results.Ok(users);
        });
    }
}