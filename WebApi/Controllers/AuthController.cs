﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Common.Auth;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController : BaseController
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("register")]
    public ActionResult<AccountModel> CreateAccount(RegisterRequest model)
    {
        var accounntdto = new AccountMapper().RegisterRequestToUserDto(model);
        authService.CreateAccount(accounntdto);
        return Ok();
    }
    
    [HttpPost("login")]
    public ActionResult<LoginResponse> Login(LoginRequest user)
    {
        var authTokensDto = authService.LoginAccount(user.Email, user.Password);

        var response = new LoginResponse(authTokensDto);

        return Ok(response);
    }
}