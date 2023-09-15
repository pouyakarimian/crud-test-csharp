using Mc2.CrudTest.Infrastructure.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mc2.CrudTest.Infrastructure.Data.Context
{
    public class ReadDbContext : IReadDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public ReadDbContext(IOptions<ConnectionOptions> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.NoSqlConnection);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }

        public static string CUSTOMERS_COLLECTION = "CUSTOMERS_COLLECTION";
        public static string EventsSTORE_COLLECTION = "EventsSTORE_COLLECTION";
    }
}
