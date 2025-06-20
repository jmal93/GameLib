using Azure.Core.Pipeline;
using game_library_backend.DataContext;
using game_library_backend.Models;

namespace game_library_backend.Services.GameService;

public class GameService : IGameInterface
{
    private readonly ApplicationDbContext _context;
    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<ServiceResponse<List<GameModel>>> CreateGame(GameModel newGame)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GameModel>>> DeleteGame(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GameModel>> GetGameById(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<GameModel>>> GetGames()
    {
        ServiceResponse<List<GameModel>> serviceResponse = new ServiceResponse<List<GameModel>>();

        try
        {
            serviceResponse.Dados = _context.Games.ToList();

            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum jogo encontrado";
            }
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public Task<ServiceResponse<List<GameModel>>> UpdateGame(GameModel updatedGame)
    {
        throw new NotImplementedException();
    }
}
