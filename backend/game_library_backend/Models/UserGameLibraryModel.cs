using Microsoft.AspNetCore.Identity;

namespace game_library_backend.Models;

public class UserGameLibraryModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public int GameId { get; set; }
    public GameModel Game { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public GameStatus Status { get; set; }
}

public enum GameStatus
{
    NotStarted,
    Playing,
    Finished,
    Abandoned,
    Wishlist
}
