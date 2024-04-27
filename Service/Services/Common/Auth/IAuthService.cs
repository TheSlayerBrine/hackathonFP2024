using System.ComponentModel.DataAnnotations;
using Data.Infrastructure.Context;
using Data.Infrastructure.UnitOfWork;

namespace Service.Services.Common.Auth;

public interface IAuthService
{
    public void CreateAccount(UserDto dto);
    public string LoginAccount(string email, string password);
}