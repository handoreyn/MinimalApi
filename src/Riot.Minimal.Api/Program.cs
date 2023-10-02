using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Endpoints;
using Riot.Minimal.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiotDatabaseContext>(opt =>
    opt.UseInMemoryDatabase("RiotDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.MapGetUsers();
app.MapUserById();
app.MapPostUser();
app.MapPutUser();
app.MapUpdatePassword();
app.MapUpdateStatus();
app.MapDeleteUser();



app.Run();