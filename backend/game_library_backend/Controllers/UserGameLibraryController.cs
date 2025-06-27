using game_library_backend.DataContext;
using game_library_backend.DTOs;
using game_library_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("addGame")]
        public async Task<IActionResult> AddGameToLibrary(AddGameToLibraryDTO dTO)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var game = await _context.Games.FindAsync(dTO.GameId);
            if (game == null) return NotFound();

            var userGame = new UserGameLibraryModel
            {
                UserId = user.Id,
                GameId = dTO.GameId,
                Status = dTO.Status
            };

            _context.UserGameLibraries.Add(userGame);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
