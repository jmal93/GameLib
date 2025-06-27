using game_library_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.DataContext;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<GameModel> Games { get; set; }
    public DbSet<GenreModel> Genres { get; set; }
    public DbSet<GameGenreModel> GameGenres { get; set; }
    public DbSet<UserGameLibraryModel> UserGameLibraries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GameGenreModel>()
            .HasKey(gg => new { gg.GameId, gg.GenreId });

        modelBuilder.Entity<GameGenreModel>()
            .HasOne(gg => gg.Game)
            .WithMany(g => g.GameGenres)
            .HasForeignKey(gg => gg.GameId);

        modelBuilder.Entity<GameGenreModel>()
            .HasOne(gg => gg.Genre)
            .WithMany(g => g.GameGenres)
            .HasForeignKey(gg => gg.GenreId);

        modelBuilder.Entity<UserGameLibraryModel>()
            .HasKey(gl => gl.Id);

        modelBuilder.Entity<UserGameLibraryModel>()
            .HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<UserGameLibraryModel>()
            .HasOne(g => g.Game)
            .WithMany()
            .HasForeignKey(g => g.GameId);
    }
}
