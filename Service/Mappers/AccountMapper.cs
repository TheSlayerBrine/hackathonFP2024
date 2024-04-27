using Riok.Mapperly.Abstractions;
using System;
using Data.Entities;
using Service.Services.Accounts;

namespace Service.Mappers;

[Mapper]
public partial class AccountMapper
{
    public partial AccountDetailsDto AccountToAccountDetailsDto(Account account);

}