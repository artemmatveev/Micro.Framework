namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Нарушение бизнес-правила
    /// </summary>
    /// <example>
    ///     Сумма превышает безопасный лимит;
    ///     Перевод из source в destination запрещен;
    /// </example>
    public sealed class BusinessRuleException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public BusinessRuleException(string message)
            : base(message)
        { }
    }
}
