using game_library_backend.DataContext;
using game_library_backend.DTOs;
using game_library_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserGameLibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserGameLibraryController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager
        )
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("{Id:int}")]
        public async Task<IActionResult> AddGameToLibrary(int Id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var game = await _context.Games.FindAsync(Id);
            if (game == null) return NotFound();

            bool gameAlreadyInLibrary = await _context.UserGameLibraries
                .AnyAsync(ug => ug.GameId == Id && ug.UserId == user.Id);
            if (gameAlreadyInLibrary)
                return BadRequest("Game already in library");

            var userGame = new UserGameLibraryModel
            {
                UserId = user.Id,
                GameId = Id,
                Status = 0
            };

            _context.UserGameLibraries.Add(userGame);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGameLibraryDTO>>> GetUserLibrary()
        {
            IEnumerable<UserGameLibraryDTO> result;
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();

                var library = await _context.UserGameLibraries
                    .Where(ug => ug.UserId == user.Id)
                    .Include(ug => ug.Game)
                        .ThenInclude(g => g.GameGenres)
                            .ThenInclude(gg => gg.Genre)
                    .Select(ug => new UserGameLibraryDTO
                    {
                        GameId = ug.GameId,
                        AddedDate = ug.AddedDate,
                        Developer = ug.Game.Developer,
                        Status = ug.Status.ToString(),
                        Title = ug.Game.Name,
                        Genres = ug.Game.GameGenres.Select(gg => gg.Genre.Name).ToList()
                    })
                    .ToListAsync();

                result = library;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }
    }
}
