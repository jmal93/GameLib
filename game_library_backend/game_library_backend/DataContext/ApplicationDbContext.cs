using game_library_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<GameModel> Games { get; set; }
}
