namespace Micro.Framework.Middleware
{
    internal static class HttpErrorResultFactory
    {
        public static (ErrorResult, int) CreatedErrorResult(RpcException ex)
        {
            var (type, statusCode) = GetErrorTypeAndStatusCode(ex);
            var error = Error.Create(type, ex.Status.Detail);

            var traceId = Guid.TryParse(ex.Trailers.GetValue("traceId"), out Guid guid)
                ? guid : Guid.NewGuid();

            return (ErrorResult.Create(error, traceId), statusCode);
        }

        public static (ErrorResult, int) CreatedErrorResult(Exception ex, Guid traceId)
        {
            var (type, statusCode) = GetErrorTypeAndStatusCode(ex);
            var error = Error.Create(type, ex?.InnerException?.Message ?? ex?.Message);

            return (ErrorResult.Create(error, traceId), statusCode);
        }

        private static (ErrorType, int) GetErrorTypeAndStatusCode(Exception ex)
            => ex switch
            {
                BadFormatOrTypeException or BadFormatOrTypeRpcException => (ErrorType.BadFormatOrType, StatusCodes.Status406NotAcceptable),
                BusinessRuleException or BusinessRuleRpcException => (ErrorType.BusinessRule, StatusCodes.Status403Forbidden),
                ConflictException or ConflictRpcException => (ErrorType.ConflictBusinessRule, StatusCodes.Status409Conflict),
                InvalidDataTypeException or InvalidDataTypeRpcException => (ErrorType.InvalidDataType, StatusCodes.Status400BadRequest),
                InvalidParameterException or InvalidParameterRpcException => (ErrorType.InvalidPathParameter, StatusCodes.Status404NotFound),
                MissingMandatoryPropertyException or MissingMandatoryPropertyRpcException => (ErrorType.MissingMandatoryProperty, StatusCodes.Status400BadRequest),
                UnsupportedLanguageException or UnsupportedLanguageRpcException => (ErrorType.UnsupportedLanguage, StatusCodes.Status406NotAcceptable),
                _ => (ErrorType.Unspecified, StatusCodes.Status500InternalServerError)
            };
    }
}
