namespace Micro.Framework.Domain
{
    public abstract class BaseEntity<TKey> : IPkEntity<TKey>
    {
        public TKey Id { get; }
    }
}
