using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQueryRequest>
    {
        public GetRoleByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
