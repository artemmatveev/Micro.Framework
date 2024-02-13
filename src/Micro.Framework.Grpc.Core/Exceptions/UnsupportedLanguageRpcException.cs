namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Запрашиваемы язык не поддерживается
    /// </summary>
    public sealed class UnsupportedLanguageRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public UnsupportedLanguageRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.InvalidArgument, message), trailers)
        { }
    }
}
