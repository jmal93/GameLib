using game_library_backend.Models;

namespace game_library_backend.DTOs;

public class UpdateGameStatusDTO
{
    public GameStatus NewGameStatus { get; set; }
}
