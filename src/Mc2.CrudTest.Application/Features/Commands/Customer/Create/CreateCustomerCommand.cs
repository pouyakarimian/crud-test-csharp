using Mc2.CrudTest.Application.Dtos.Customer;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.Features.Commands.Customer.Create
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public CreateCustomerCommand(string firstName, string lastName,
            string phoneNumber, string bankAccountNumber,
            string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public CreateCustomerCommand()
        {

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]

        public string PhoneNumber { get; set; }

        public string BankAccountNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
