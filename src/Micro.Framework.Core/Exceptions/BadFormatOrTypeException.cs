namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Не верный формат или тип
    /// </summary>
    public sealed class BadFormatOrTypeException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public BadFormatOrTypeException(string message)
            : base(message)
        { }
    }
}
