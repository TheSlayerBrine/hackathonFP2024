using Service.Services.Common.Auth;
using WebApi.Models;

namespace WebApi.Mappers;

public static class AuthMapper
{
    public static LoginDto ToDto(this LoginRequest model)
    {
        return new LoginDto
        {
            Email = model.Email,
            Password = model.Password
        };
    }
   
}