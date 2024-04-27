using Microsoft.Build.Framework;

namespace WebApi.Models;

public class LoginRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}