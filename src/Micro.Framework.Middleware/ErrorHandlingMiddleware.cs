namespace Micro.Framework.Middleware
{
    public sealed class ErrorHandlingMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<ErrorHandlingMiddleware> _logger;
        readonly IOptions<JsonOptions> _jsonOptions;
        readonly Guid _traceId;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger,
            IOptions<JsonOptions> jsonOptions)
        {
            _next = next;
            _logger = logger;
            _jsonOptions = jsonOptions;
            _traceId = Guid.NewGuid();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (RpcException ex)
            {
                await HandleGrpcExceptionAsync(httpContext, _logger, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, _logger, ex, _traceId);
            }
        }

        private async Task HandleGrpcExceptionAsync(HttpContext context, ILogger logger, RpcException ex)
        {
            var traceId = ex.Trailers.GetValue("traceId");
            logger.LogError(ex.Status.Detail, $"TraceId: {traceId}");

            var (errorResult, statusCode) = HttpErrorResultFactory.CreatedErrorResult(ex);
            await CreateErrorResponse(context, errorResult, statusCode);
        }

        private async Task HandleExceptionAsync(HttpContext context, ILogger logger,
            Exception ex, Guid traceId)
        {
            logger.LogError(ex, $"TraceId: {traceId}");

            var (errorResult, statusCode) = HttpErrorResultFactory.CreatedErrorResult(ex, traceId);
            await CreateErrorResponse(context, errorResult, statusCode);
        }

        private async Task CreateErrorResponse(HttpContext context, ErrorResult errorResult, int statusCode)
        {
            var options = _jsonOptions.Value.JsonSerializerOptions;
            var result = JsonSerializer.Serialize(errorResult, options);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(result);
        }
    }
}
