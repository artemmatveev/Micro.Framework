namespace Micro.Framework.Middleware
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddJsonOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            return services;
        }
    }
}
