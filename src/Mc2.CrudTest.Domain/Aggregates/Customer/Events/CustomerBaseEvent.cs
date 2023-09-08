using Mc2.CrudTest.Domain.BaseDomain;

namespace Mc2.CrudTest.Domain.Aggregates.Customer.Events;

public abstract class CustomerBaseEvent : BaseEvent
{
    protected CustomerBaseEvent(
        Guid id,
        string firstName,
        string lastName,
        string phoneNumber,
        string bankAccountNumber,
        string email,
        DateTime dateOfBirth)
    {
        Id = id;
        AggregateId = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BankAccountNumber = bankAccountNumber;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public Guid Id { get; private init; }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    public string PhoneNumber { get; private init; }
    public string BankAccountNumber { get; private init; }
    public string Email { get; private init; }
    public DateTime DateOfBirth { get; private init; }
}