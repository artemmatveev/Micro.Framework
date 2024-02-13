namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Отсутствует обязательное свойство
    /// </summary>
    /// <example>
    ///     Не указана сумма
    /// </example>
    public sealed class MissingMandatoryPropertyRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public MissingMandatoryPropertyRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.InvalidArgument, message), trailers)
        { }
    }
}
