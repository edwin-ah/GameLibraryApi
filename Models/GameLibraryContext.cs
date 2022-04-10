using Microsoft.EntityFrameworkCore;

namespace GameLibraryApi.Models
{
    public class GameLibraryContext : DbContext
    {
        public GameLibraryContext(DbContextOptions<GameLibraryContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; } = null!;
    }
}
