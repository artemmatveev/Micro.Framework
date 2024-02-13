namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Конфлик при выполнении бизнес-правила
    /// </summary>
    /// <example>
    ///     За последние 5 минут уже был выполнен идентичный перевод
    /// </example>
    public sealed class ConflictRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public ConflictRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.AlreadyExists, message), trailers)
        { }
    }
}
