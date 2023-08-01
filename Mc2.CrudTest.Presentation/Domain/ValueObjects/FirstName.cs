using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project1.Domain.Common;
using Project1.Domain.Constants;

namespace Project1.Domain.ValueObjects;

public class FirstName : ValueObject
{
    public string Value { get; private set; }

    public FirstName(string value)
    {
        Value = value;
    }

    public static Response<FirstName> Create(string value)
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrEmpty(value))
            errors.Add("Firstname can not be null");
        if (value.Length < 2)
            errors.Add("Min lengh of first name is 2 char");
        if (value.Length > 50)
            errors.Add("Max lengh of first name is 50 char");
        
        if (errors.Count > 0)
        {
            return new Response<FirstName>(null, errors);
        }
        return new Response<FirstName>(new FirstName(value), true);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
