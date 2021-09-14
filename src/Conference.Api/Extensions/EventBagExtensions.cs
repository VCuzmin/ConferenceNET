using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Conference.Api.Extensions
{
    public static class EventBagExtensions
    {
        public static IServiceCollection AddEventsBag(this IServiceCollection services)
        {
            services.AddSingleton<IEventsBagAccessor, EventsBagAccessor>();
            return services;
        }

        public static IApplicationBuilder AddEventsBag(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var bag = context.RequestServices.GetService<IEventsBagAccessor>();
                bag.Events = new List<INotification>();
                await next();
            });
            return app;
        }
    }
}
