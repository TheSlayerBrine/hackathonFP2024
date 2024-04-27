using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase
{
        protected int? UserId
    {
        get
        {
            if (HttpContext is null || HttpContext.User is null)
            {
                return null;
            }

            var currentUser = HttpContext.User;

            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return null;
            }

            var contextUserId = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
            var isParsed = int.TryParse(contextUserId, out int userId);

            return isParsed ? userId : null;
        }
    }

    protected void ValidateModel()
    {
        if (!ModelState.IsValid)
        {
            //throw new InvalidModelStateException(ModelState);
        }
    }

    protected void ValidateUserId()
    {
        if (UserId is null)
        {
            throw new ArgumentNullException(nameof(UserId), "User Id not found");
        }
    }
}

