namespace Micro.Framework.Domain
{
    public interface IBaseAmqpAuditableEntity
    {
        string EventType { get; set; }
        object Payload { get; set; }
        string Topic { get; set; }
        DateTime CreationTime { get; set; }
        DateTime? SentTime { get; set; }
    }
}
