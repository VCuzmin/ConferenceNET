using Conference.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NBB.Data.EntityFramework;
using NBB.Data.EventSourcing;

namespace Conference_Data
{
    public static class DependencyInjectionExtensions
    {
        public static void AddConferencesDataAccess(this IServiceCollection services)
        {
            services.AddEntityFrameworkDataAccess();
            services.AddEventSourcingDataAccess((sp, builder) =>
                builder.Options.DefaultSnapshotVersionFrequency = 10);

            services.AddEntityFrameworkSqlServer()
                .AddDbContextPool<ConferenceDbContext>(
                    (serviceProvider, options) =>
                    {
                        var configuration = serviceProvider.GetService<IConfiguration>();
                        var connectionString = configuration.GetConnectionString("Conference_Database");

                        options
                            .UseSqlServer(connectionString, builder => { builder.EnableRetryOnFailure(3); })
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                    });

            services.AddScoped<IConferenceRepository, IConferenceRepository>();
        }

    }
}