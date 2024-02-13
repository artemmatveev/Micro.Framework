namespace Micro.Framework.Grpc.Interceptors
{
    using Services;

    public sealed class GrpcErrorHandlingInterceptor : Interceptor
    {
        readonly ILogger<GrpcErrorHandlingInterceptor> _logger;
        readonly Guid _traceId;

        public GrpcErrorHandlingInterceptor(ILogger<GrpcErrorHandlingInterceptor> logger)
        {
            _logger = logger;
            _traceId = Guid.NewGuid();
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await base.UnaryServerHandler(request, context, continuation);
            }
            catch (Exception ex)
            {
                throw await GrpcHandleExceptionAsync(_logger, ex, _traceId);
            }
        }

        private async Task<RpcException> GrpcHandleExceptionAsync(ILogger logger, Exception ex, Guid traceId)
        {
            logger.LogError(ex, $"TraceId: {traceId}");

            return RpcExceptionFactory.CreateRpcException(ex, traceId);
        }
    }
}
