using Mc2.CrudTest.Domain.BaseDomain;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories.BaseRepositories
{
    public interface ICustomerReadOnlyRepository: IReadOnlyRepository<EventStore, Guid>
    {
        Task<IEnumerable<EventStore>> GetAllAsync();
    }
}
