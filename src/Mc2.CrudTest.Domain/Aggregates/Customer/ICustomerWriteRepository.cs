using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Aggregates.Customer
{
    public interface ICustomerWriteRepository: IWriteOnlyRepository<Customer,Guid>
    {
        Task<bool> ExistsByEmailAsync(Email email);

        Task<bool> ExistsByEmailAsync(Email email, Guid currentId);
    }
}
