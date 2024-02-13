namespace Micro.Framework.Rest.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Options;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRestPresentation(this IApplicationBuilder app,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(Constants.CORS_POLICY_NAME);

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                var options = configuration.GetSection(SwaggerOptions.Swagger).Get<SwaggerOptions>();

                o.DocumentTitle = $"{options.Title} REST API";
                o.SwaggerEndpoint("/swagger/v1/swagger.json", $"{options.Title}Api.v1");
            });

            return app;
        }
    }
}
