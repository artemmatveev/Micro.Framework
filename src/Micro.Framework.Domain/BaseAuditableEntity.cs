namespace Micro.Framework.Domain
{
    public abstract class BaseAuditableEntity<TPKey> : BaseEntity<TPKey>, IBaseAuditableEntity
    {
        public BaseAuditableEntity()
        {
            CreationTime = ModificationTime = DateTime.Now;
        }

        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}