using Microsoft.AspNetCore.Mvc;
using Service.Services.Accounts;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Controllers;


[ApiController]
[Route("api/account")]
public class AccountController : BaseController
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }
    [HttpGet("getAccountDetails")]
    public ActionResult<AccountDetailsModel> GetAccountDetails()
    {
        ValidateUserId();

        var accountDetailsDto = accountService.GetDetails(UserId.Value);

        return Ok(new AccountMapper().AccountDetailsDtoToAccountDetailsModel(accountDetailsDto));
    }
}