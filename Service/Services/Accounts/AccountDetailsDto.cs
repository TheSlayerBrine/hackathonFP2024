namespace Service.Services.Accounts;

public class AccountDetailsDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string ProfilePicture { get; set; }
    
}