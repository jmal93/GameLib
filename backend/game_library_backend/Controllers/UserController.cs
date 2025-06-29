using game_library_backend.DataContext;
using game_library_backend.DTOs;
using game_library_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager
        ) : ControllerBase
    {
        [HttpGet("{Email}")]
        public async Task<ActionResult<UserDTO>> GetUserProfile(string Email)
        {
            UserDTO result;
            try
            {
                var user = await userManager.Users
                    .FirstOrDefaultAsync(x => x.Email == Email);

                if (user == null) return NotFound();
                if (user.Email == null || user.UserName == null)
                    return BadRequest("Invalid credentials");

                UserDTO userDTO = new()
                {
                    Email = user.Email,
                    UserName = user.UserName
                };

                result = userDTO;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

        [HttpGet("library")]
        public async Task<ActionResult<IEnumerable<UserGameLibraryDTO>>> GetUserLibrary()
        {
            IEnumerable<UserGameLibraryDTO> result;
            try
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();

                var library = await context.UserGameLibraries
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

        [HttpPost("library/{Id:int}")]
        public async Task<IActionResult> AddGameToLibrary(int Id)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var game = await context.Games.FindAsync(Id);
            if (game == null) return NotFound();

            bool gameAlreadyInLibrary = await context.UserGameLibraries
                .AnyAsync(ug => ug.GameId == Id && ug.UserId == user.Id);
            if (gameAlreadyInLibrary)
                return BadRequest("Game already in library");

            var userGame = new UserGameLibraryModel
            {
                UserId = user.Id,
                GameId = Id,
                Status = 0
            };

            context.UserGameLibraries.Add(userGame);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
