using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Dtos.Customer
{
    public class CustomerDto
    {
        public CustomerDto()
        {

        }

        public CustomerDto(string firstName, string lastName, string phoneNumber, 
            string bankAccountNumber, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string BankAccountNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
