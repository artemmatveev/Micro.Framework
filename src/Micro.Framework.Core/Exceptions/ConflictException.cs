namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Конфликт при выполнении бизнес-правила
    /// </summary>
    /// <example>
    ///     За последние 5 минут уже был выполнен идентичный перевод
    /// </example>
    public sealed class ConflictException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public ConflictException(string message)
            : base(message)
        { }
    }
}
