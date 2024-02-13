namespace Micro.Framework.Rest.Options
{
    public sealed record SwaggerOptions(string Title, string Version)
    {
        public const string Swagger = nameof(Swagger);

        public SwaggerOptions()
            : this(string.Empty, "1.0")
        { }
    }
}
