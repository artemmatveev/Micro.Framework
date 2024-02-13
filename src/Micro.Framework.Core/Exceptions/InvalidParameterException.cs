namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Неправильный параметр пути
    /// </summary>
    /// <example>
    ///     Чтение несуществующего счета с помощью запроса GET /accounts/123
    /// </example>
    public sealed class InvalidParameterException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public InvalidParameterException(string message)
            : base(message)
        { }
    }
}
