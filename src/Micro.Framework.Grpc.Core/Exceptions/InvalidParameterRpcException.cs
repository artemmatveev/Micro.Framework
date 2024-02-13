namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Неправильный параметр пути
    /// </summary>
    /// <example>
    ///     Чтение несущесвующего счета с помощью запроса GET /accounts/123
    /// </example>
    public sealed class InvalidParameterRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public InvalidParameterRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.NotFound, message), trailers)
        { }
    }
}
