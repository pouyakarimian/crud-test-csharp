using System.Diagnostics.CodeAnalysis;
using Mc2.CrudTest.Domain.Aggregates.Customer;
using Mc2.CrudTest.Domain.BaseDomain;
using Mc2.CrudTest.Infrastructure.Data.Context;
using Mc2.CrudTest.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Data;

namespace Mc2.CrudTest.Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{
    /// <summary>
    /// Adds the infrastructure services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddScoped<CrudTestDbContext>()
            //.AddScoped<EventStoreDbContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>();

    /// <summary>
    /// Adds the write-only repositories to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public static IServiceCollection AddWriteOnlyRepositories(this IServiceCollection services) =>
         services
            //.AddScoped<IEventStoreRepository, EventStoreRepository>()
            .AddScoped<ICustomerWriteRepository, CustomerWriteOnlyRepository>();
}