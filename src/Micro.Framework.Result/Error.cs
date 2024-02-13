namespace Micro.Framework.Result
{
    public sealed record Error(ErrorType type, string? message)
    {
        public static Error Create(ErrorType type, string? message)
        {
            return new Error(type, message);
        }
    }
}