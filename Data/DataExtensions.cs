using MusicWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicWorksAPI.Data
{

    public static class DataExtensions
    {
        public static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider
                .GetRequiredService<MusicWorksAPIContext>();
            dbContext.Database.Migrate();


            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(SeedData.SeedCategories);

                dbContext.SaveChanges();
            }

            if (!dbContext.Works.Any())
            {
                dbContext.Works.AddRange(SeedData.SeedWorks);

                dbContext.SaveChanges();
            }

        }

        public static void AddMusicWorksAPIDb(this WebApplicationBuilder builder)
        {
            var connString = builder.Configuration.GetConnectionString("MusicWorksAPI");

            builder.Services.AddSqlite<MusicWorksAPIContext>(connString);
        }

    }
}
