namespace Micro.Framework.Grpc.Extentions
{
    using Interceptors;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddIemsGrpc(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddGrpc(o =>
            {
                o.Interceptors.Add<GrpcErrorHandlingInterceptor>();
            });

            // Включение поддержки gRPC Server Reflection
            services.AddGrpcReflection();

            return services;
        }
    }
}
