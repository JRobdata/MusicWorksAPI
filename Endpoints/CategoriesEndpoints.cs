using Microsoft.EntityFrameworkCore;
using MusicWorksAPI.Data;
using MusicWorksAPI.Dtos;

namespace MusicWorksAPI.Endpoints
{
    public static class CategoriesEndpoints
    {   
        public static void MapCategoriesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/categories");

            // GET /categories
            group.MapGet("/", async (MusicWorksAPIContext dbContext) =>
            await dbContext.Categories
                .Select(category => new CategoryDto
                (
                    category.Id,
                    category.Name
                )).AsNoTracking()
                .ToListAsync());
        }
    }
}
