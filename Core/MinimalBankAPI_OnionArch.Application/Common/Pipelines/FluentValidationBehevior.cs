using FluentValidation;
using MediatR;

namespace MinimalBankAPI_OnionArch.Application.Common.Pipelines
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failture = _validator
              .Select(x => x.Validate(context))
              .SelectMany(result => result.Errors)
              .GroupBy(x => x.ErrorMessage)
              .Select(x => x.First())
              .Where(x => x != null)
              .ToList();

            if (failture.Any())
            {
                throw new ValidationException(failture);
            }

            return next();
        }
    }




}
