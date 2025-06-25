using System.Threading.Tasks;
using game_library_backend.DataContext;
using game_library_backend.DTOs;
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
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGames()
        {
            IEnumerable<GameDTO> result;

            try
            {
                result = await _context.Games
                    .Include(g => g.GameGenres)
                    .ThenInclude(gg => gg.Genre)
                    .Select(g => new GameDTO
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Developer = g.Developer,
                        Image = g.Image,
                        ReleaseDate = g.ReleaseDate,
                        Price = g.Price,
                        Genres = g.GameGenres.Select(gg => new GenreDTO
                        {
                            Id = gg.Genre.Id,
                            Name = gg.Genre.Name
                        }).ToList()
                    })
                    .ToListAsync();

                if (!result.Any())
                {
                    return Ok("No games available");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GameDTO>> GetGameById(int Id)
        {
            GameDTO result;
            try
            {
                var game = await _context.Games
                    .Include(g => g.GameGenres)
                    .ThenInclude(gg => gg.Genre)
                    .FirstOrDefaultAsync(g => g.Id == Id);

                if (game == null)
                {
                    return NotFound();
                }

                GameDTO gameDTO = new()
                {
                    Id = game.Id,
                    Name = game.Name,
                    ReleaseDate = game.ReleaseDate,
                    Price = game.Price,
                    Developer = game.Developer,
                    Image = game.Image,
                    Genres = [.. game.GameGenres.Select(gg => new GenreDTO
                    {
                        Id = gg.Genre.Id,
                        Name = gg.Genre.Name
                    })]
                };

                result = gameDTO;
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
