using System.Text.Json.Serialization;

namespace Riot.Minimal.Api.Persistence.Entities;

public sealed class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public StatusEnumType Status { get; set; }

    public User(int id, string username, string email, string password, StatusEnumType status = StatusEnumType.Active)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Status = status;
    }

    public User(string username, string email, string password, StatusEnumType status = StatusEnumType.Active)
    {
        Username = username;
        Email = email;
        Password = password;
        Status = status;
    }
}