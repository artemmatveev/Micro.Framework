namespace Micro.Framework.Domain
{
    public abstract class BaseAmqpAuditableEntiry<TPKey> : BaseEntity<TPKey>, IBaseAmqpAuditableEntity
    {
        private Regex SERVER_NAME_REGEX = new Regex(@"^\w*\.\w*.\w*", RegexOptions.Compiled);
        private string? _typeName;
        private string? _assemblyName;

        public BaseAmqpAuditableEntiry(string eventType, object payload, string topic)
        {
            EventType = eventType;
            Payload = payload;
            Topic = topic;
        }

        public string EventType { get; set; }
        public object Payload { get; set; }
        public string Topic { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? SentTime { get; set; }


        public string TypeName
        {
            get
            {
                if (_typeName is null)
                {
                    var exchangeArray = Topic.Replace(':', '.').Split('.');
                    var upperExchangeArray = exchangeArray
                        .Select(s => string.Concat(s[0].ToString().ToUpper(), s.AsSpan(1)))
                        .ToArray();

                    _typeName = string.Join('.', upperExchangeArray);
                }

                return _typeName;
            }
        }

        public string AssemblyName
        {
            get
            {
                if (_assemblyName is null)
                {
                    _assemblyName = SERVER_NAME_REGEX.Match(TypeName).Value;
                }

                return _assemblyName;
            }
        }


        public void Send()
        {
            if (SentTime is null)
            {
                SentTime = DateTime.Now;
            }
        }
    }
}
