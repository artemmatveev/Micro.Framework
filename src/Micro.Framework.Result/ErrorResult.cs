namespace Micro.Framework.Result
{
    public sealed record ErrorResult : BaseResult
    {
        public ErrorResult(IEnumerable<Error> errors, Guid traceId)
            : base(ResultStatus.Error)
        {
            Errors = errors;
            TraceId = traceId;
        }

        public IEnumerable<Error> Errors { get; init; }

        public Guid TraceId { get; init; }

        public static ErrorResult Create(Error error, Guid traceId)
            => new ErrorResult(new List<Error>(1) { error }, traceId);

        public static ErrorResult Create(IEnumerable<Error> errors, Guid traceId)
            => new ErrorResult(errors, traceId);
    }
}
