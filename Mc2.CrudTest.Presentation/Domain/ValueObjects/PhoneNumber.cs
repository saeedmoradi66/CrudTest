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
    public static Response<PhoneNumber> Create(string input)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add("PhoneNumber can not be null");
        string email = input.Trim();

        if (email.Length > 11)
            errors.Add("Max lengh of  PhoneNumber is 11 char");

        if (!Regex.IsMatch(email, ValidationConstant.CellphonePattern))
            errors.Add("PhoneNumber is not valid");

        if (errors.Count > 0)
        {
            return new Response<PhoneNumber>(null, errors);
        }
        return new Response<PhoneNumber>(new PhoneNumber(input), true);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
