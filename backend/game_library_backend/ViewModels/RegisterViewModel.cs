using System.ComponentModel.DataAnnotations;

namespace game_library_backend.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public required string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public required string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
