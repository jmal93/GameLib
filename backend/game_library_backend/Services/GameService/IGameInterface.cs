using game_library_backend.Models;

namespace game_library_backend.Services.GameService;

public interface IGameInterface
{
    Task<List<GameModel>> GetGames();
    Task<List<GameModel>> CreateGame(GameModel newGame);
    Task<GameModel> GetGameById(int Id);
    Task<List<GameModel>> UpdateGame(GameModel updatedGame);
    Task<List<GameModel>> DeleteGame(int Id);
}
