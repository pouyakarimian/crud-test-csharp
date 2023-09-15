namespace Mc2.CrudTest.Domain.BaseDomain;

/// <summary>
/// Represents a repository for storing events in an event store.
/// </summary>
public interface IEventStoreRepository
{
    /// <summary>
    /// Stores a collection of event stores asynchronously.
    /// </summary>
    /// <param name="eventStores">The event stores to store.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task StoreAsync(IEnumerable<EventStore> eventStores);
}