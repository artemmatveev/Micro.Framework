namespace Micro.Framework.Grpc.Services
{
    internal static class RpcExceptionFactory
    {
        public static RpcException CreateRpcException(Exception ex, Guid traceId)
        {
            var message = (ex?.InnerException?.Message ?? ex?.Message)!;
            var exception = ex switch
            {
                BadFormatOrTypeException => new BadFormatOrTypeRpcException(message, CreateTrailers(traceId)),
                BusinessRuleException => new BusinessRuleRpcException(message, CreateTrailers(traceId)),
                ConflictException => new ConflictRpcException(message, CreateTrailers(traceId)),
                InvalidDataTypeException => new InvalidDataTypeRpcException(message, CreateTrailers(traceId)),
                InvalidParameterException => new InvalidParameterRpcException(message, CreateTrailers(traceId)),
                MissingMandatoryPropertyException => new MissingMandatoryPropertyRpcException(message, CreateTrailers(traceId)),
                UnsupportedLanguageException => new UnsupportedLanguageRpcException(message, CreateTrailers(traceId)),
                _ => (RpcException)new UnexpectedRpcException(message, CreateTrailers(traceId))
            };

            return exception;
        }

        private static Metadata CreateTrailers(Guid traceId)
        {
            var trailers = new Metadata
            {
                { "traceId", traceId.ToString() }
            };
            return trailers;
        }
    }
}