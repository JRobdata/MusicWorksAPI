using MusicWorksAPI.Endpoints;
using MusicWorksAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddMusicWorksAPIDb();

var app = builder.Build();

app.MapWorksEndpoints();
app.MapCategoriesEndpoints();

app.MigrateDb();

app.Run();