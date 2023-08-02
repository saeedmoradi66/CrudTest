using FluentValidation.Results;

namespace Project1.Application.Common.Exceptions;
public class ValidationException : Exception
{
    public ValidationException(IReadOnlyCollection<ValidationError> failures)
        : base("One or more validation failures have occurred.")
    {
        Errors = failures;
    }

    public IReadOnlyCollection<ValidationError> Errors { get; }
}
public record ValidationError(string PropertyName,string ErrorMessage);