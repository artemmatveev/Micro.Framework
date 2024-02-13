namespace Micro.Framework.Result.Values
{
    public sealed record Page<T> : Collection<T>
    {
        public Page(IEnumerable<T> items, int pageNumber, int pageSize, int totalRecors) : base(items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecors;
            TotalPages = Convert.ToInt32(Math.Ceiling(((double)totalRecors / (double)PageSize)));
        }

        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages { get; init; }
    }
}
