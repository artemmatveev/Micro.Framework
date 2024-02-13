namespace Micro.Framework.Domain
{
    public interface IBaseAuditableEntity
    {
        DateTime CreationTime { get; set; }
        DateTime ModificationTime { get; set; }
    }
}
