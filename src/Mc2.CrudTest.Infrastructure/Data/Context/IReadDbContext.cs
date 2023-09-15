using MongoDB.Driver;

namespace Mc2.CrudTest.Infrastructure.Data.Context
{
    public interface IReadDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
