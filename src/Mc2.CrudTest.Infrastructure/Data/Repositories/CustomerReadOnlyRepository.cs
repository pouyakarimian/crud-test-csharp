using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Infrastructure.Data.Context;
using Mc2.CrudTest.Infrastructure.Data.Repositories.BaseRepositories;
using MongoDB.Driver;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        private readonly IReadDbContext _context;
        public CustomerReadOnlyRepository(IReadDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventStore>> GetAllAsync()
        {
            var result = await _context
            .GetCollection<EventStore>(nameof(EventStore))
            .Find(Builders<EventStore>.Filter.Empty)
            .ToListAsync();

            return result;
        }

        public async Task<EventStore> GetByIdAsync(Guid id)
        {
            var result = await _context
                  .GetCollection<EventStore>(nameof(EventStore))
                  .Find(queryModel => queryModel.Id.Equals(id))
                  .FirstOrDefaultAsync();

            return result;

        }
    }
}
