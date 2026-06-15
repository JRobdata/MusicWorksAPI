using Microsoft.EntityFrameworkCore;
using MusicWorksAPI.Models;


namespace MusicWorksAPI.Data
{
    public class MusicWorksAPIContext(DbContextOptions<MusicWorksAPIContext> options)
        : DbContext(options)
    {
        public DbSet<Work> Works => Set<Work>();

        public DbSet<Category> Categories => Set<Category>();
    }
}