using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        Validate(value);
        Value = value;
    }

    private static void Validate(string value)
    {
        List<ValidationError> errors = new List<ValidationError>();
        if (string.IsNullOrEmpty(value))
            errors.Add(new Exceptions.ValidationError (  "FirstName",  "value can not be null" ));
        if (value.Length < 2)
            errors.Add(new Exceptions.ValidationError("FirstName", "Min lengh of first name is 2 char"));
        if (value.Length > 50)
            errors.Add(new Exceptions.ValidationError("FirstName", "Max lengh of first name is 50 char"));
        
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
