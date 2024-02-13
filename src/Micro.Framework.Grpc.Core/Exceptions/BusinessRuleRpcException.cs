namespace Micro.Framework.Grpc.Core.Exceptions
{
    /// <summary>
    ///     Нарушение бизнес-правила
    /// </summary>
    /// <example>
    ///     Сумма превышает безопасный лимит;
    ///     Перевод из source в destination запрещен;
    /// </example>
    public sealed class BusinessRuleRpcException : RpcExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public BusinessRuleRpcException(string message, Metadata trailers)
            : base(new Status(StatusCode.PermissionDenied, message), trailers)
        { }
    }
}
