using System.Text.RegularExpressions;

namespace Micro.Framework.Common.Extensions
{
    public static class TypeExtensions
    {
        public static string ConvertToTopicName(this Type type)
        {            
            var topicArray = type.FullName.Split('.');
            var lowerTopicArray = topicArray
                .Select(s => string.Concat(s[0].ToString().ToLower(), s.AsSpan(1)))
                .ToArray();

            return Regex.Replace(string.Join('.', lowerTopicArray), "\\.(?=[^.]*$)", ":");
        }
    }
}
