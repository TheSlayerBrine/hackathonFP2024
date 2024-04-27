using Data.Infrastructure.UnitOfWork;

namespace Service.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public AccountDetailsDto GetDetails(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateUserName(int id, string newUserName)
    {
        var account = unitOfWork.Accounts.Find(id);
        if(account == null)
        {
            throw new Exception("Account not found");
        }
    }

    public void UpdateEmail(int id, string newEmail)
    {
      
    }
}