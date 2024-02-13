namespace Micro.Framework.RabbitMq.Extentions
{
    using Options;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAsyncPresentation(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment env, Type[] markerTypes)
        {
            services.AddAsyncApiSchemaGeneration(o =>
            {
                var options = configuration.GetSection(AsyncApiOptions.AsyncApi).Get<AsyncApiOptions>();

                o.AssemblyMarkerTypes = markerTypes;

                o.Middleware.Route = "/asyncapi/asyncapi.json";
                o.Middleware.UiBaseRoute = "/asyncapi/";
                o.Middleware.UiTitle = $"{options.Title} Async API Documentation";

                o.AsyncApi = new AsyncApiDocument
                {
                    Info = new Info($"{options.Title} Async API", 
                        Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString())
                    {
                        Description = $"AsyncApi Spec for {options.Title} Async API"
                    }
                };
            });

            return services;
        }
    }
}
