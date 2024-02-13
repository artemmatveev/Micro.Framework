namespace Micro.Framework.RabbitMq.Options
{
    public sealed record AsyncApiOptions(string Title)
    {
        public const string AsyncApi = nameof(AsyncApi);

        public AsyncApiOptions()
            : this(string.Empty) 
        { }
    }
}
