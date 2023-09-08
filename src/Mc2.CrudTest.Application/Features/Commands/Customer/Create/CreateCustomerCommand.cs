using Mc2.CrudTest.Application.Dtos.Customer;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Application.Features.Commands.Customer.Create
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]

        public string PhoneNumber { get; set; }

        public string BankAccountNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
