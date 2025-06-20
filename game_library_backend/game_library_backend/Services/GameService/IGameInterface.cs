using game_library_backend.Models;

namespace game_library_backend.Services.GameService;

public interface IGameInterface
{
    Task<ServiceResponse<List<GameModel>>> GetGames();
    Task<ServiceResponse<List<GameModel>>> CreateGame(GameModel newGame);
    Task<ServiceResponse<GameModel>> GetGameById(int Id);
    Task<ServiceResponse<List<GameModel>>> UpdateGame(GameModel updatedGame);
    Task<ServiceResponse<List<GameModel>>> DeleteGame(int Id);
}
