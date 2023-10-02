using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Persistence;

namespace Riot.Minimal.Api.Endpoints;

public static class ChangePassword
{
    public static void MapUpdatePassword(this WebApplication app)
    {
        app.MapPut("/{id}/change-password", async (int id, UpdatePasswordModel model, RiotDatabaseContext db, CancellationToken cancellationToken) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id && u.Status == Persistence.Entities.StatusEnumType.Active, cancellationToken);
            if (user is null) return Results.BadRequest();

            if (!model.Password.Equals(model.PasswordValidate)) return Results.BadRequest();

            user.Password = model.Password;
            await db.SaveChangesAsync(cancellationToken);
            return Results.NoContent();
        });
    }
}

public record UpdatePasswordModel(string Password, string PasswordValidate);