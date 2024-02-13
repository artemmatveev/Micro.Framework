namespace Micro.Framework.Rest.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Options;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRestPresentation(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddCors(o =>
                o.AddPolicy(Constants.CORS_POLICY_NAME,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    }));

            services.AddSwaggerGen(c =>
            {
                var options = configuration.GetSection(SwaggerOptions.Swagger).Get<SwaggerOptions>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{options.Title} REST API",
                    Version = Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString(),
                    Description = $"OpenApi Spec for {options.Title} REST API"
                });

                var xmlFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.Controllers.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, true);
                c.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}
