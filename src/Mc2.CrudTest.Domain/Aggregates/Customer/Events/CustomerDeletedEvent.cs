using System;

namespace Mc2.CrudTest.Domain.Aggregates.Customer.Events;

public class CustomerDeletedEvent : CustomerBaseEvent
{
    public CustomerDeletedEvent(
        Guid id,
        string firstName,
        string lastName,
        string phoneNumber,
        string bankAccountNumber,
        string email,
        DateTime dateOfBirth) : base(id, firstName, lastName, phoneNumber, bankAccountNumber, email, dateOfBirth)
    {
    }
}