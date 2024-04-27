namespace Service.Services.Accounts;

public interface IAccountService
{
    public AccountDetailsDto GetDetails(int id);
    public void UpdateUserName(int id, string newUserName);
    public void UpdateEmail(int id, string newEmail);
}