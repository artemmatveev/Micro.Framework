namespace Micro.Framework.RabbitMq.Extentions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseAsyncPresentation(this IApplicationBuilder app,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            app.UseEndpoints(e => e.UseAsyncEndpoint());

            return app;
        }

        private static IEndpointRouteBuilder UseAsyncEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapAsyncApiDocuments();
            endpoints.MapAsyncApiUi();

            return endpoints;
        }
    }
}
