using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Infrastructure.Data.Context;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly IReadDbContext _context;

        public EventStoreRepository(IReadDbContext context) =>
            _context = context;

        public async Task StoreAsync(IEnumerable<EventStore> eventStores)
        {
            await _context
                .GetCollection<EventStore>(nameof(EventStore))
                .InsertManyAsync(eventStores);
        }
    }
}
