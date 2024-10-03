using MinimalBankAPI_OnionArch.Application.Common.RuleBases;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Rules.Exceptions
{
    public class CustomerAlreadyExistException : BaseException
    {
        public CustomerAlreadyExistException() : base("Customer already exists.") { }
    }
    public class CustomerDoesNotExistException : BaseException
    {
        public CustomerDoesNotExistException() : base("Customer does not exists.") { }
    }
    public class CustomerLoggedOutExistException : BaseException
    {
        public CustomerLoggedOutExistException() : base("Session time has expired. Please log in again.") { }
    }
    public class PasswordDoesNotMatched : BaseException
    {
        public PasswordDoesNotMatched() : base("Wrong password.") { }
    }
}
