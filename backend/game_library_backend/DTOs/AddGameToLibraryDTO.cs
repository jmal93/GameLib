using game_library_backend.Models;

namespace game_library_backend.DTOs;

public class AddGameToLibraryDTO
{
    public int GameId { get; set; }
    public GameStatus Status { get; set; }
}
