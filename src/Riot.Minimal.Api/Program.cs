using Microsoft.EntityFrameworkCore;
using Riot.Minimal.Api.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RiotDatabaseContext>(opt =>
    opt.UseInMemoryDatabase("RiotDb"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
