namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Неверный тип данных
    /// </summary>
    public sealed class InvalidDataTypeRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public InvalidDataTypeRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.InvalidArgument, message), trailers)
        { }
    }
}
