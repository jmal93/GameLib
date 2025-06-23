using System.Threading.Tasks;
using game_library_backend.DataContext;
using game_library_backend.Models;
using game_library_backend.Services.GameService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GameModel>>> GetGames()
        {
            List<GameModel> result = new List<GameModel>();

            try
            {
                result = await _context.Games.ToListAsync();

                if (result.Count == 0)
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GameModel>> GetGameById(int Id)
        {
            GameModel result;
            try
            {
                GameModel? game = await _context.Games
                    .FirstOrDefaultAsync(x => x.Id == Id);

                if (game == null)
                {
                    return NoContent();
                }

                result = game;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<GameModel>>> CreateGame(GameModel newGame)
        {
            try
            {
                if (newGame == null)
                {
                    return BadRequest("Jogo não informado");
                }
                _context.Add(newGame);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult<List<GameModel>>> UpdateGame(GameModel updatedGame)
        {
            try
            {
                GameModel? game = await _context.Games
                    .AsNoTracking().FirstOrDefaultAsync(x => x.Id == updatedGame.Id);

                if (game == null)
                {
                    return NotFound();
                }

                _context.Games.Update(updatedGame);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Game updated");
        }

        [HttpDelete]
        public async Task<ActionResult<List<GameModel>>> DeleteGame(int Id)
        {
            try
            {
                GameModel? game = await _context.Games.FirstOrDefaultAsync(x => x.Id == Id);

                if (game == null)
                {
                    return NotFound();
                }

                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Game deleted");
        }
    }
}
