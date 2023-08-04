using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class LastName:ValueObject
{
    public string Value { get; private set; }

    public LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string value)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrEmpty(value))
            errors.Add(new Exceptions.ValidationError("LastName", "value can not be null"));
        if (value.Length < 2)
            errors.Add(new Exceptions.ValidationError("LastName", "Min lengh of last name is 2 char"));
        if (value.Length > 50)
            errors.Add(new Exceptions.ValidationError("LastName", "Max lengh of last name is 50 char"));
        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException(errors);
        }
        return new LastName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
