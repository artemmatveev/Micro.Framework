namespace Micro.Framework.Core.Exceptions
{
    /// <summary>
    ///     Базовый класс ошибки
    /// </summary>
    [Serializable]
    public abstract class ExceptionBase : Exception
    {
        public ExceptionBase() { }

        public ExceptionBase(string message)
          : base(message) { }

        public ExceptionBase(string message, Exception innerException)
           : base(message, innerException) { }

        protected ExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
