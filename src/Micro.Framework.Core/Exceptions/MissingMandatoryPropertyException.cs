namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Отсутствует обязательное свойство
    /// </summary>
    /// <example>
    ///     Не указана сумма
    /// </example>
    public sealed class MissingMandatoryPropertyException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public MissingMandatoryPropertyException(string message)
            : base(message)
        { }
    }
}
