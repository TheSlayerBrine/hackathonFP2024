using Service.Enums;

namespace Service.Exceptions;

public class ThirdPartyException : BaseException
{
    public ThirdPartyException() : base(ErrorCodes.GenericThirdPartyError) { }

    public ThirdPartyException(string message) : base(ErrorCodes.GenericThirdPartyError, message) { }

    public ThirdPartyException(string message, Exception innerException) : base(ErrorCodes.GenericThirdPartyError, message, innerException) { }

    public ThirdPartyException(ErrorCodes code, string message, Exception innerException) : base(code, message, innerException) { }

    public ThirdPartyException(ErrorCodes code, string message) : base(code, message) { }

    public ThirdPartyException(ErrorCodes code) : base(code) { }
}