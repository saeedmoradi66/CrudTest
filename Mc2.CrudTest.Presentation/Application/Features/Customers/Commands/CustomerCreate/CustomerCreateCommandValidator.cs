using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Project1.Application.Common.Interfaces.Repository;
using Project1.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Application.Features.Customers.Commands.CustomerCreate
{
    public class CustomerCreateCommandValidator : AbstractValidator<CustomerCreateCommand>
    {
        public CustomerCreateCommandValidator(ICustomerRepository customerRepository)
        {
            
            RuleFor(c => c).MustAsync(async (email,cancelatin) =>
            {
                return await customerRepository.IsEmailUniqueAsync(email.CustomerViewModel.Email);
            }
            ).WithName("email").WithMessage("the email must be unique");

            RuleFor(c => c).MustAsync(async (c, _) =>
            {
                return await customerRepository.IsCustomerUniqueAsync(
                 c.CustomerViewModel.FirstName,
                 c.CustomerViewModel.LastName,
                c.CustomerViewModel.DateOfBirth);
            }).WithName("FirstName&LastName&DateOfBirth").WithMessage("the customer must be unique");
        }
        
    }
}
