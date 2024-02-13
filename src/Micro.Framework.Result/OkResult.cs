namespace Micro.Framework.Result
{
    public record OkResult : BaseResult
    {
        public OkResult() : base(ResultStatus.Ok)
        { }        

        public static OkResult Create()
            => new OkResult();
    }

    public sealed record OkResult<T> : OkResult 
    {
        public OkResult(T value)
        {
            Value = value;
        }

        public T Value { get; init; }

        public static OkResult<T> Create(T value)
            => new OkResult<T>(value);
    }
}
