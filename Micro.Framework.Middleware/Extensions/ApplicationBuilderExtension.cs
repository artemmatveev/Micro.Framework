namespace Micro.Framework.Middleware.Extensions
{
    using Middleware;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseRestErrorMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            return app;
        }
    }
}
