using Project1.Domain.Constants;
using System.Text.RegularExpressions;

namespace Project1.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Value { get; private set; }
    public PhoneNumber(string value)
    {
        Validate(value);
        Value = value;
    }
    private static void Validate(string input)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add(new Exceptions.ValidationError("PhoneNumber", "PhoneNumber can not be null"));
        string email = input.Trim();

        if (email.Length > 11)
            errors.Add(new Exceptions.ValidationError("PhoneNumber", "Max lengh of  PhoneNumber is 11 char"));

        if (!Regex.IsMatch(email, ValidationConstant.CellphonePattern))
            errors.Add(new Exceptions.ValidationError("PhoneNumber", "PhoneNumber is not valid"));

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
