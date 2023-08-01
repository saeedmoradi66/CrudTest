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
    public Customer(int? id, FirstName firstName, LastName lastName, DateOfBirth dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
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

    public static Response<Customer> Create(string firstName, string lastName, string dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {

        var result = new Response<Customer>();
        result.ErrorList = new();

        var firstNameResult = FirstName.Create(value: firstName);
        if (firstNameResult.ErrorList != null)
            result.ErrorList.AddRange(firstNameResult.ErrorList);

        var lastNameResult = LastName.Create(value: lastName);
        if (lastNameResult.ErrorList != null)
            result.ErrorList.AddRange(lastNameResult.ErrorList);

        var dateOfBirthResult = DateOfBirth.Create(dateOfBirth);
        if (dateOfBirthResult.ErrorList != null)
            result.ErrorList.AddRange(dateOfBirthResult.ErrorList);

        var phoneNumberResult = PhoneNumber.Create(phoneNumber);
        if (phoneNumberResult.ErrorList != null)
            result.ErrorList.AddRange(phoneNumberResult.ErrorList);

        var emailResult = Email.Create(email);
        if (emailResult.ErrorList != null)
            result.ErrorList.AddRange(emailResult.ErrorList);

        var bankAccountNumberResult = BankAccountNumber.Create(bankAccountNumber);
        if (bankAccountNumberResult.ErrorList != null)
            result.ErrorList.AddRange(bankAccountNumberResult.ErrorList);

        if (result.ErrorList.Count>0)
        {
            result.Succeeded = false;
            return result;
        }

        Customer customer = new(null, firstNameResult.Data, lastNameResult.Data, dateOfBirthResult.Data, phoneNumberResult.Data, emailResult.Data, bankAccountNumberResult.Data);

        return new Response<Customer>(customer, true);
    }

    public static Response<Customer> Update(int id, string firstName, string lastName, string email, string phoneNumber, string dateOfBirth, string bankAccountNumber)
    {
        var result = Create(firstName, lastName, email, phoneNumber, dateOfBirth, bankAccountNumber);

        if (result.Succeeded == false)
        {
            return result;
        }

        result.Data.Id = id;

        return result;
    }
}
