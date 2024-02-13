namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Неверный тип данных
    /// </summary>
    public sealed class InvalidDataTypeException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public InvalidDataTypeException(string message)
            : base(message)
        { }
    }
}
