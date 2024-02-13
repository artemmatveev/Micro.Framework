namespace Micro.Framework.EntityFrameworkCore.SqlServer.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        ///     Преобразует строку ToSnakeCase к виду to_shake_case.
        ///     Для foreignKey добавляет постфикс _id.
        /// </summary>        
        public static string ToSnakeCase(this string str, bool asForeignKey = false)
        {
            Regex pattern = new Regex(@"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+");
            string result = string.Join("_", pattern.Matches(str)).ToLower();

            return asForeignKey ? result + "_id" : result;
        }
    }
}
