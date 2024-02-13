namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Не верный формат или тип
    /// </summary>
    public sealed class BadFormatOrTypeRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public BadFormatOrTypeRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.InvalidArgument, message), trailers)
        { }
    }
}
