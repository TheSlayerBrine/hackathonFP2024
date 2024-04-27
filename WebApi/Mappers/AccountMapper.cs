using Riok.Mapperly.Abstractions;
using Service.Services.Accounts;
using Service.Services.Common.Auth;
using WebApi.Models;

namespace WebApi.Mappers;

[Mapper]
public partial class AccountMapper
{
    public partial AccountDetailsModel AccountDetailsDtoToAccountDetailsModel(AccountDetailsDto dto);
    public partial UserDto RegisterRequestToUserDto(RegisterRequest model);
}