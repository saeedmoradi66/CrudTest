using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class DateOfBirth : ValueObject
{
    public string Value { get; private set; }
    public DateOfBirth(string value)
    {
        Value = value;
    }
    public static Response<DateOfBirth> Create(string input)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add("DateOfBirth can not be null");
        
        if (input.Length > 10)
            errors.Add("DateOfBirth is 10 char ex:1366/01/09");
        if (errors.Count > 0)
        {
            return new Response<DateOfBirth>(null, errors);
        }
        return new Response<DateOfBirth>(new DateOfBirth(input), true);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}