namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Запрашиваемы язык не поддерживается
    /// </summary>
    public sealed class UnsupportedLanguageException : ExceptionBase
    {
        /// <summary>
        ///     ctr
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public UnsupportedLanguageException(string message)
            : base(message)
        { }
    }
}
