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

    public static Response<Email> Create(string input)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add("Email can not be null");
        string email = input.Trim();

        if (email.Length > 256)
            errors.Add("Max lengh of email is 256 char");

        if (!Regex.IsMatch(email, ValidationConstant.EmailPattern))
            errors.Add("Email is not valid");

        if (errors.Count > 0)
        {
            return new Response<Email>(null, errors);
        }
        return new Response<Email>(new Email(input), true);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
