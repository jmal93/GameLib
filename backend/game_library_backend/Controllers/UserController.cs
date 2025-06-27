using game_library_backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace game_library_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{Email}")]
        public async Task<ActionResult<UserDTO>> GetUserProfile(string Email)
        {
            UserDTO result;
            try
            {
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(x => x.Email == Email);

                if (user == null)
                {
                    return NotFound();
                }

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
    }
}
