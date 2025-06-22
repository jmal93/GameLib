using Azure.Core.Pipeline;
using game_library_backend.DataContext;
using game_library_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Services.GameService;

public class GameService : IGameInterface
{
    private readonly ApplicationDbContext _context;
    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<GameModel>>> CreateGame(GameModel newGame)
    {
        ServiceResponse<List<GameModel>> serviceResponse = new ServiceResponse<List<GameModel>>();

        try
        {
            if (newGame == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Dados não informados";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }
            _context.Add(newGame);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Games.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GameModel>>> DeleteGame(int Id)
    {
        ServiceResponse<List<GameModel>> serviceResponse = new ServiceResponse<List<GameModel>>();

        try
        {
            GameModel game = _context.Games.FirstOrDefault(x => x.Id == Id);

            if (game == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogo não encontrado";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Games.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GameModel>> GetGameById(int Id)
    {
        ServiceResponse<GameModel> serviceResponse = new ServiceResponse<GameModel>();

        try
        {
            GameModel game = _context.Games.FirstOrDefault(x => x.Id == Id);

            if (game == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogo não encontrado";
                serviceResponse.Sucesso = false;
            }

            serviceResponse.Dados = game;
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
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

    public async Task<ServiceResponse<List<GameModel>>> UpdateGame(GameModel updatedGame)
    {
        ServiceResponse<List<GameModel>> serviceResponse = new ServiceResponse<List<GameModel>>();

        try
        {
            GameModel game = _context.Games.AsNoTracking().FirstOrDefault(x => x.Id == updatedGame.Id);

            if (game == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Jogo não encontrado";
                serviceResponse.Sucesso = false;
            }

            _context.Games.Update(updatedGame);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Games.ToList();
        }
        catch (Exception e)
        {
            serviceResponse.Mensagem = e.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}
