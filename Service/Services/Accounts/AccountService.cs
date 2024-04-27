using Data.Infrastructure.UnitOfWork;
using Service.Mappers;

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
        var account = unitOfWork.Accounts.Find(id);
        if(account == null)
        {
            throw new Exception("Account not found");
        }
       var accountDetailsDto = new AccountMapper().AccountToAccountDetailsDto(account);
       return accountDetailsDto;
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