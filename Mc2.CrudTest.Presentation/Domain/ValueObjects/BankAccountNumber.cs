using System.Text.RegularExpressions;
using Project1.Domain.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class BankAccountNumber : ValueObject
{
    public string Value { get; private set; }
    public BankAccountNumber(string value)
    {
        Validate(value);
        Value = value;
    }
    private static void Validate(string input)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add(new Exceptions.ValidationError("BankAccountNumber", "Bank Account Number can not be null"));
        string email = input.Trim();

        if (email.Length > 24)
            errors.Add(new Exceptions.ValidationError("BankAccountNumber", "Max lengh of Bank Account Number is 24 char"));

        if (!Regex.IsMatch(email, ValidationConstant.BankAccountNumber))
            errors.Add(new Exceptions.ValidationError("BankAccountNumber", "Bank Account Number is not valid"));

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