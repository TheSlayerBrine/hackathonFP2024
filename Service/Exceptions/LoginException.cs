using Service.Enums;

namespace Service.Exceptions;

public class LoginException : BaseException
{
    public LoginException(string message) : base(ErrorCodes.GenericAuthenticationError, message)
    {
    }

    public LoginException(ErrorCodes code, string message) : base(code, message) { }
}