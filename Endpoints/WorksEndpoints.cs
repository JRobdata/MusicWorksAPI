using Microsoft.EntityFrameworkCore; 
using MusicWorksAPI.Data;
using MusicWorksAPI.Dtos;
using MusicWorksAPI.Models;

namespace MusicWorksAPI.Endpoints
{
    public static class WorksEndpoints
    {
        const string GetWorkEndpointName = "getWork";
        public static void MapWorksEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/works");

            // GET /works
            group.MapGet("/", async (MusicWorksAPIContext dbContext) =>
            await dbContext.Works
                .Select(work => new WorkSummaryDto(
                    work.Id,
                    work.Title,
                    work.Category!.Name,
                    work.Instrumentation,
                    work.Price,
                    work.PublicationYear
                )).AsNoTracking()
                .ToListAsync());

            // Get /works/1
            group.MapGet("/{id}", async (int id, MusicWorksAPIContext dbContext) =>
            {
                var work = await dbContext.Works.FindAsync(id);

                return work is null ? Results.NotFound() : Results.Ok(
                   new WorkDetailsDto(
                        work.Id,
                        work.Title,
                        work.CategoryId,
                        work.Instrumentation,
                        work.Price,
                        work.PublicationYear
                   )
                );
            })
                .WithName(GetWorkEndpointName);

            // Post /works
            group.MapPost("/", async (CreateWorkDto newWork, MusicWorksAPIContext dbContext) =>
            {
                if (string.IsNullOrWhiteSpace(newWork.Title))
                {
                    return Results.BadRequest("A title is required.");
                }

                if (newWork.CategoryId <= 0)
                {
                    return Results.BadRequest("Category is required.");
                }

                if (newWork.Price <= 0)
                {
                    return Results.BadRequest("Price must be greater than 0.");
                }

                Work work = new Work()
                {
                    Title = newWork.Title,
                    CategoryId = newWork.CategoryId,
                    Instrumentation = newWork.Instrumentation,
                    Price = newWork.Price,
                    PublicationYear = newWork.PublicationYear,
                };

                dbContext.Works.Add(work);
                await dbContext.SaveChangesAsync();

                WorkDetailsDto workDto = new WorkDetailsDto(

                    work.Id,
                    work.Title,
                    work.CategoryId,
                    work.Instrumentation,
                    work.Price,
                    work.PublicationYear
                );

                return Results.CreatedAtRoute(GetWorkEndpointName, new
                {
                    id = workDto.Id
                },
                workDto);
            });

            // PUT /works/1
            group.MapPut("/{id}", async (int id, UpdateWorkDto updatedWork,
                                    MusicWorksAPIContext dbContext) =>
            {
                if (string.IsNullOrWhiteSpace(updatedWork.Title))
                {
                    return Results.BadRequest("Title is required.");
                }

                if (updatedWork.CategoryId <= 0)
                {
                    return Results.BadRequest("Category is required.");
                }

                if (updatedWork.Price <= 0)
                {
                    return Results.BadRequest("Price must be greater than 0.");
                }

                var existingWork = await dbContext.Works.FindAsync(id);

                if (existingWork is null)
                {
                    return Results.NotFound();
                }

                existingWork.Title = updatedWork.Title;
                existingWork.CategoryId = updatedWork.CategoryId;
                existingWork.Instrumentation = updatedWork.Instrumentation;
                existingWork.Price = updatedWork.Price;
                existingWork.PublicationYear = updatedWork.PublicationYear;

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            // DELETE /works/1
            group.MapDelete("/{id}", async (int id, MusicWorksAPIContext dbContext) =>
            {

                var rowsDeleted = await dbContext.Works
                               .Where(work => work.Id == id)
                               .ExecuteDeleteAsync();

                return rowsDeleted == 0 ? Results.NotFound() : Results.NoContent();

            });
        }
    }
}

