namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Неожиданная ошибка сервера
    /// </summary>
    /// <example>
    ///     Ошибка реализации
    /// </example>
    public sealed class UnexpectedRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public UnexpectedRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.Internal, message), trailers)
        { }
    }
}
