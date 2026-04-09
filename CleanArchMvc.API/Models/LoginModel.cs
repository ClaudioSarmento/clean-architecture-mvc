using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.API.Models;

public class LoginModel
{

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, ErrorMessage = "Password must be at least 6 characters long", MinimumLength = 6)]
    public string Password { get; set; } = default!;
}
