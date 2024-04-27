namespace WebApi.Models;

public class RegisterRequest
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ProfilePicture { get; set; }
}