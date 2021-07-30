using Microsoft.Extensions.DependencyInjection;

namespace Conference.Api.Swagger
{
    public static class SwaggerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>        
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Conference Api",
                        Version = "v1"
                    }
                );

                c.CustomSchemaIds(type => type.ToString());
            });

            return services;
        }
    }
}