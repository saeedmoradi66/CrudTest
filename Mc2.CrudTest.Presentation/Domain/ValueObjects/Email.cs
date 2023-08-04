using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project1.Domain.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;
public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
    }

    public static Email Create(string input)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add(new Exceptions.ValidationError("Email","Email can not be null"));
        string email = input.Trim();

        if (email.Length > 256)
            errors.Add(new Exceptions.ValidationError("Email","Max lengh of email is 256 char"));

        if (!Regex.IsMatch(email, ValidationConstant.EmailPattern))
            errors.Add(new Exceptions.ValidationError("Email","Email is not valid"));

        if (errors.Count > 0)
        {
            throw new Exceptions.ValidationException(errors);
        }
        return new Email(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
