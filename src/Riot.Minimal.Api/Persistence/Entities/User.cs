namespace Riot.Minimal.Api.Persistence.Entities;

public sealed class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public StatusEnumType Status { get; set; }

    public User(int id, string username, string email, StatusEnumType status = StatusEnumType.Active)
    {

    }
}