using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.Data.QueriesModel
{
    public class CustomerQueryModel : IQueryModel<Guid>
    {
        public CustomerQueryModel(Guid id, string firstName,
            string lastName, string phoneNumber,
            BankAccountNumber bankAccountNumber,
            Email email, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Guid Id { get; private init; }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public BankAccountNumber BankAccountNumber { get; private set; }

        public Email Email { get; private set; }

        public DateTime DateOfBirth { get; private set; }
    }
}
