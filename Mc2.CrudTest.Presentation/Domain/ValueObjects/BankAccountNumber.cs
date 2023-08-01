using System.Text.RegularExpressions;
using Project1.Domain.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project1.Domain.ValueObjects;

public class BankAccountNumber : ValueObject
{
    public string Value { get; private set; }
    public BankAccountNumber(string value)
    {
        Value = value;
    }
    public static Response<BankAccountNumber> Create(string input)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrWhiteSpace(input))
            errors.Add("Bank Account Number can not be null");
        string email = input.Trim();

        if (email.Length > 24)
            errors.Add("Max lengh of Bank Account Number is 24 char");

        if (!Regex.IsMatch(email, ValidationConstant.BankAccountNumber))
            errors.Add("Bank Account Number is not valid");

        if (errors.Count > 0)
        {
            return new Response<BankAccountNumber>(null, errors);
        }
        return new Response<BankAccountNumber>(new BankAccountNumber(input), true);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}