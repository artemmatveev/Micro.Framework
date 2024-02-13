namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Неожиданная ошибка сервера
    /// </summary>
    /// <example>
    ///     Ошибка реализации
    /// </example>
    public sealed class UnexpectedException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public UnexpectedException(string message)
            : base(message)
        { }
    }
}
