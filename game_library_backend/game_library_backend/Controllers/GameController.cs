using System.Threading.Tasks;
using game_library_backend.Models;
using game_library_backend.Services.GameService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace game_library_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameInterface _gameInterface;
        public GameController(IGameInterface gameInterface)
        {
            _gameInterface = gameInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GameModel>>>> GetGames()
        {
            return Ok(await _gameInterface.GetGames());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GameModel>>>> CreateGame(GameModel newGame)
        {
            return Ok(await _gameInterface.CreateGame(newGame));
        }
    }
}
