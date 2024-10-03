using FluentValidation;

namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryValidation : AbstractValidator<GetAllRolesQueryRequest>
    {
        public GetAllRolesQueryValidation()
        {
            RuleFor(x=>x.CurrentPage).GreaterThanOrEqualTo(0);
            RuleFor(x=>x.PageSize).GreaterThanOrEqualTo(0);

        }
    }
}
