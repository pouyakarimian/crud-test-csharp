using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Infrastructure.Data.Context;
using MongoDB.Driver;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories.BaseRepositories
{
    public abstract class BaseReadOnlyRepository<TQueryModel, Tkey> : IReadOnlyRepository<TQueryModel, Tkey>
    //where TQueryModel : IQueryModel<Tkey>
    where Tkey : IEquatable<Tkey>
    {
        protected readonly IMongoCollection<TQueryModel> Collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReadOnlyRepository{TQueryModel, Tkey}"/> class.
        /// </summary>
        /// <param name="context">The read database context.</param>
        protected BaseReadOnlyRepository(IReadDbContext context, string collectionName) =>
            Collection = context.GetCollection<TQueryModel>(collectionName);

        /// <summary>
        /// Gets a query model by its id.
        /// </summary>
        /// <param name="id">The id of the query model.</param>
        /// <returns>The query model.</returns>
        public async Task<TQueryModel> GetByIdAsync(Tkey id) =>
            await Collection.Find(queryModel => queryModel.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
