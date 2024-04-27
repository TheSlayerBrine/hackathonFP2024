using Data.Enums;

namespace Data.Entities;

public class Account
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string ProfilePicture { get; set; }
}