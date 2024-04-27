using Riok.Mapperly.Abstractions;
using Service.Services.Accounts;
using WebApi.Models;

namespace WebApi.Mappers;

[Mapper]
public partial class AccountMapper
{
    public partial AccountDetailsModel AccountDetailsDtoToAccountDetailsModel(AccountDetailsDto dto);
}