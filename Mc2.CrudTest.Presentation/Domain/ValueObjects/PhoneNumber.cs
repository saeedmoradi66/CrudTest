using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Project1.Domain.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Value { get; private set; }
    public PhoneNumber(string value)
    {
        Value = value;
    }
    public static PhoneNumber Create(string input)
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
        return new PhoneNumber(input);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
