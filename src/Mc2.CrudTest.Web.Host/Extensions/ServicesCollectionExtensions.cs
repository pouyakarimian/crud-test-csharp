using System.Reflection;
using Mc2.CrudTest.Domain.Extensions;
using Mc2.CrudTest.Infrastructure.Data.Context;
using Mc2.CrudTest.Web.Host.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Mc2.CrudTest.Web.Host.Extensions;

internal static class ServicesCollectionExtensions
{
    private static readonly string[] DatabaseTags = { "database" };

    public static IServiceCollection ConfigureAppSettings(this IServiceCollection services) =>
       services
           .AddOptionsWithValidation<ConnectionOptions>();

    /// <summary>
    /// Adds options with validation to the service collection.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to add.</typeparam>
    /// <param name="services">The service collection.</param>
    private static IServiceCollection AddOptionsWithValidation<TOptions>(this IServiceCollection services)
        where TOptions : class, IAppOptions
    {
        return services
            .AddOptions<TOptions>()
            .BindConfiguration(TOptions.ConfigSectionPath, binderOptions => binderOptions.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart()
            .Services;
    }

    public static IServiceCollection AddWriteDbContext(this IServiceCollection services)
    {
        services.AddDbContext<CrudTestDbContext>((serviceProvider, optionsBuilder) =>
            ConfigureDbContext(serviceProvider, optionsBuilder, QueryTrackingBehavior.TrackAll));

        //services.AddDbContext<EventStoreDbContext>((serviceProvider, optionsBuilder) =>
            //ConfigureDbContext<EventStoreDbContext>(serviceProvider, optionsBuilder, QueryTrackingBehavior.NoTrackingWithIdentityResolution));

        return services;
    }


    private static void ConfigureDbContext(
        IServiceProvider serviceProvider,
        DbContextOptionsBuilder optionsBuilder,
        QueryTrackingBehavior queryTrackingBehavior)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<CrudTestDbContext>>();
        var connectionOptions = serviceProvider.GetOptions<ConnectionOptions>();

        optionsBuilder
            .UseSqlServer(connectionOptions.SqlConnection, sqlServerOptions =>
            {
                sqlServerOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                sqlServerOptions.EnableRetryOnFailure(3);
                sqlServerOptions.CommandTimeout(30);
            })
            .UseQueryTrackingBehavior(queryTrackingBehavior)
            .LogTo((eventId, _) => eventId.Id == CoreEventId.ExecutionStrategyRetrying, eventData =>
            {
                if (eventData is not ExecutionStrategyEventData retryEventData)
                    return;

                var exceptions = retryEventData.ExceptionsEncountered;

                logger.LogWarning(
                    "----- DbContext: Retry #{Count} with delay {Delay} due to error: {Message}",
                    exceptions.Count,
                    retryEventData.Delay,
                    exceptions[^1].Message);
            });

        // Get the current hosting environment.
        var environment = serviceProvider.GetRequiredService<IHostEnvironment>();
        if (environment.IsDevelopment())
        {
            // Enable detailed errors for debugging purposes.
            optionsBuilder.EnableDetailedErrors();

            // Enable sensitive data logging for debugging purposes.
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}