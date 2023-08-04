using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project1.Domain.ValueObjects;

namespace Project1.Domain.Entities;
public class Customer : AggregateRoot
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public BankAccountNumber BankAccountNumber { get; private set; }
    private Customer()
    {
        
    }
    private Customer(int? id, FirstName firstName, LastName lastName, DateOfBirth dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
    {
        if (id.HasValue)
            Id = id.Value;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        PhoneNumber = phoneNumber;
        BankAccountNumber = bankAccountNumber;
    }

    public static Customer Create(string firstName, string lastName, string dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {

        var firstNameResult = FirstName.Create(value: firstName);
        
        var lastNameResult = LastName.Create(value: lastName);
        
        var dateOfBirthResult = DateOfBirth.Create(dateOfBirth);
       
        var phoneNumberResult = PhoneNumber.Create(phoneNumber);
       
        var emailResult = Email.Create(email);
       
        var bankAccountNumberResult = BankAccountNumber.Create(bankAccountNumber);
        
        Customer customer = new(null, firstNameResult, lastNameResult, dateOfBirthResult, phoneNumberResult, emailResult, bankAccountNumberResult);

        return customer;
    }

    public static Customer Update(int id, string firstName, string lastName, string email, string phoneNumber, string dateOfBirth, string bankAccountNumber)
    {
        var result = Create(firstName, lastName, email, phoneNumber, dateOfBirth, bankAccountNumber);

        result.Id = id;

        return result;
    }
}
