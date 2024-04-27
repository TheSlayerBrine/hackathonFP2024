using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Entities;
using Data.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Exceptions;

namespace Service.Services.Common.Auth;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IConfiguration config;

    public AuthService(IUnitOfWork unitOfWork, IConfiguration config)
    {
        this.unitOfWork = unitOfWork;
        this.config = config;
    }

    public void CreateAccount(UserDto dto)
    {
        var account = unitOfWork.Accounts.GetByEmail(dto.Email);
        if(account != null)
        {
            throw new Exception("Account already exists");
        }
        account = new Account
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Password = dto.Password,
            ProfilePicture = dto.ProfilePicture
        };
        unitOfWork.Accounts.Add(account);
        unitOfWork.SaveChanges();
    }

    public string LoginAccount(string email, string password)
    {
        var account = unitOfWork.Accounts.GetByEmail(email);
        if (account is null)
        {
            throw new LoginException("User doesn't exist");
        }

        if (account.Email != email)
        {
            throw new LoginException("Credentials are not matching");
        }

        return GenerateJwt(account);
    }

   
    private string GenerateJwt(Account account)
    {
        var securityKey = new SymmetricSecurityKey((Encoding.UTF8.GetBytes(config["Jwt:Key"])));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
        };
        var token = new JwtSecurityToken(config["Jwt:Issuer"],
            config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(2000),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}