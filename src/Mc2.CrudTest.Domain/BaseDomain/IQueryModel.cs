using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.BaseDomain
{
    public interface IQueryModel
    {
    }
    /// <summary>
    /// Represents the interface for a query model with a generic key type.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IQueryModel<out TKey> : IQueryModel where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the ID of the query model.
        /// </summary>
        TKey Id { get; }
    }
}
