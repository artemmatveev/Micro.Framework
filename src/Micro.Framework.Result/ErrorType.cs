namespace Micro.Framework.Result
{
    public enum ErrorType : byte
    {
        /// <summary>
        ///     Не известно
        /// </summary>
        Unspecified,
        /// <summary>
        ///     Неправильный параметр пути запроса
        /// </summary>
        InvalidPathParameter,
        /// <summary>
        ///     Отсутствует обязательное свойство
        /// </summary>
        MissingMandatoryProperty,
        /// <summary>
        ///     Неверный тип данных
        /// </summary>
        InvalidDataType,
        /// <summary>
        ///     Функциональная/бизнесовая ошибка
        /// </summary>
        BusinessRule,
        /// <summary>
        ///     Конфликтная функциональная/бизнесовая ошибка
        /// </summary>
        ConflictBusinessRule,
        /// <summary>
        ///     Не поддерживаемый язык
        /// </summary>
        UnsupportedLanguage,
        /// <summary>
        ///     Неверный формат или тип
        /// </summary>
        BadFormatOrType,
        /// <summary>
        ///     Неожиданная ошибка сервера
        /// </summary>
        Unexpected
    }
}
