using MinimalBankAPI_OnionArch.Application.Common.RuleBases;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Rules.Exceptions;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Rules
{
    public class RoleRules : BaseRules
    {
        public Task EnsureRolerNotExists(MinimalBankAPI_OnionArch.Domain.Entities.Auth.Role? role)
        {
            if (role is not null) throw new RoleAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EnsureRoleExists(MinimalBankAPI_OnionArch.Domain.Entities.Auth.Role? role)
        {
            if (role is null) throw new RoleDoesNotExistException();
            return Task.CompletedTask;
        }
    }
}
