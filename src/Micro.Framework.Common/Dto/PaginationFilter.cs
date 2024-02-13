namespace Micro.Framework.Common.Dto
{
    public record PaginationFilter
    {
        private int _pageNumber;
        private int _pageSize;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 0 ? 0 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 10 ? 10 : value;
        }

        public PaginationFilter()
        {
            this.PageNumber = 0;
            this.PageSize = 10;
        }
    }
}
