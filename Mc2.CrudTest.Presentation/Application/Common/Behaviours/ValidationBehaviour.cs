using FluentValidation;
using MediatR;
using Project1.Domain.Exceptions;

namespace Project1.Application.Common.Behaviours;
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators
                .Select(v => v.ValidateAsync(context))
                );
            var validationResults = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(v => v.Errors)
                .Select(v => new ValidationError(

                    v.PropertyName,
                    v.ErrorMessage
                )).ToList();



            if (validationResults.Any())
                throw new Domain.Exceptions.ValidationException(validationResults);
        }
        return await next();
    }
}
