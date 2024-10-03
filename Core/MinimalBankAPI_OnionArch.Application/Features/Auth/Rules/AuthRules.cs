using MinimalBankAPI_OnionArch.Application.Common.RuleBases;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Rules.Exceptions;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Security.Hashing;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {

        public Task EnsureCustomerNotExists(Customer? customer)
        {
            if (customer is not null) throw new CustomerAlreadyExistException();
            return Task.CompletedTask;
        }

        public Task EnsureCustoemrExists(Customer? customer)
        {
            if (customer is null) throw new CustomerDoesNotExistException();
            return Task.CompletedTask;
        }

        public Task EnsurePasswordIsCorrect(Customer customer, string password)
        {
            bool isPasswordMatch = HashingHelper.VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt);
            if (!isPasswordMatch) { throw new PasswordDoesNotMatched(); }
            return Task.CompletedTask;
        }

        public Task EnsureCustomerNotLogOut(DateTime? refreshTokenExpireTime)
        {
            if (refreshTokenExpireTime <= DateTime.Now)
            {
                throw new CustomerLoggedOutExistException();
            }
            return Task.CompletedTask;
        }
    }
}
