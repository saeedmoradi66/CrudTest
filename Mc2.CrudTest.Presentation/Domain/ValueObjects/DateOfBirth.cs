using Project1.Domain.Constants;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class DateOfBirth : ValueObject
{
    public string Value { get; private set; }
    public DateOfBirth(string value)
    {
        Validate(value);
        Value = value;
    }
    private static void Validate(string input)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add(new Exceptions.ValidationError("DateOfBirth", "DateOfBirth can not be null"));
        if (input.Length > 10)
            errors.Add(new Exceptions.ValidationError("DateOfBirth","DateOfBirth is 10 char ex:1366/01/09"));
        
        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException(errors);
        }
        
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}