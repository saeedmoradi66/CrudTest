using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class LastName:ValueObject
{
    public string Value { get; private set; }

    public LastName(string value)
    {
        Value = value;
    }

    public static Response<LastName> Create(string value)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrEmpty(value))
            errors.Add("LastName can not be null");
        if (value.Length < 2)
            errors.Add("Min lengh of last name is 2 char");
        if (value.Length > 50)
            errors.Add("Max lengh of last name is 50 char");
        if (errors.Count > 0)
        {
            return new Response<LastName>(null, errors);
        }
        return new Response<LastName>(new LastName(value), true);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
