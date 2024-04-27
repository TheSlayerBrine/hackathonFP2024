using Data.Enums;

namespace WebApi.Models;

public class AccountDetailsModel
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string ProfilePicture { get; set; }
    public Role Role { get; set; }
}