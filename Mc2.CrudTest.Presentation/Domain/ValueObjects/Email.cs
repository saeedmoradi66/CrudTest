using Project1.Domain.Constants;
using System.Text.RegularExpressions;

namespace Project1.Domain.ValueObjects;
public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Validate(value);
        Value = value;
    }

    private static void Validate(string input)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add(new Exceptions.ValidationError("Email", "Email can not be null"));
        string email = input.Trim();

        if (email.Length > 256)
            errors.Add(new Exceptions.ValidationError("Email", "Max lengh of email is 256 char"));

        if (!Regex.IsMatch(email, ValidationConstant.EmailPattern))
            errors.Add(new Exceptions.ValidationError("Email", "Email is not valid"));

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
