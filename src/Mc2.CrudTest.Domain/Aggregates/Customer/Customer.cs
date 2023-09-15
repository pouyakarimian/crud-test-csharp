using Mc2.CrudTest.Domain.Aggregates.Customer.Events;
using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Aggregates.Customer
{
    public class Customer : BaseEntity, IAggregateRoot
    {

        /// <summary>
        /// Default constructor for Entity Framework or other ORM frameworks.
        /// </summary>
        private Customer()
        {
        }

        public Customer(string firstName, string lastName, string phoneNumber,
            BankAccountNumber bankAccountNumber, Email email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

    
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public BankAccountNumber BankAccountNumber { get; private set; }

        public Email Email { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// Changes the email address of the customer.
        /// </summary>
        /// <param name="newEmail">The new email address.</param>
        public void ChangeEmail(Email newEmail)
        {
            if (Email.Equals(newEmail))
                return;

            Email = newEmail;

            AddDomainEvent(new CustomerUpdatedEvent(Id, FirstName, LastName, PhoneNumber, BankAccountNumber.Number, newEmail.Address, DateOfBirth));
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        public void Delete()
        {
            IsDeleted = true;
            AddDomainEvent(new CustomerDeletedEvent(Id, FirstName, LastName, PhoneNumber, BankAccountNumber.Number, Email.Address, DateOfBirth));
        }
    }
}
