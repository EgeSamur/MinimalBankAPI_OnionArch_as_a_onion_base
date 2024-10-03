using MinimalBankAPI_OnionArch.Application.Common.RuleBases;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Rules.Exceptions
{
    public class RoleAlreadyExistException : BaseException
    {
        public RoleAlreadyExistException() : base("Role already exists.") { }
    }
    public class RoleDoesNotExistException : BaseException
    {
        public RoleDoesNotExistException() : base("Role does not exists.") { }
    }
}
