namespace Micro.Framework.Domain
{
    /* out в genegic говорит о том, что тип является ковариантным 
     * https://learn.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/covariance-contravariance/ */

    public interface IPkEntity<out TKey>
    {
        public TKey Id { get; }
    }
}
