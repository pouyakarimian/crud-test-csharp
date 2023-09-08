using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data.Repositories.BaseRepositories;

/// <summary>
/// Base class for write-only repositories.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="Tkey">The type of the entity's key.</typeparam>
public abstract class BaseWriteOnlyRepository<TEntity, Tkey> : IWriteOnlyRepository<TEntity, Tkey>
    where TEntity : class, IEntity<Tkey>
    where Tkey : IEquatable<Tkey>
{
    private readonly DbSet<TEntity> _dbSet;
    protected readonly CrudTestDbContext Context;

    protected BaseWriteOnlyRepository(CrudTestDbContext context)
    {
        Context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task Add(TEntity entity) =>
       await _dbSet.AddAsync(entity);

    public void Update(TEntity entity) =>
        _dbSet.Update(entity);

    public void Remove(TEntity entity) =>
        _dbSet.Remove(entity);

    public async Task<TEntity> GetByIdAsync(Tkey id) =>
        await _dbSet
        .AsNoTrackingWithIdentityResolution()
        .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    ~BaseWriteOnlyRepository() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
            Context.Dispose();

        _disposed = true;
    }

    #endregion
}