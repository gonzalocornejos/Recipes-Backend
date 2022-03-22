namespace recipes_backend.Helpers.Query
{
    public class PagedQuery<T> where T : class
    {
        public T Filter { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }

        public PagedQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }
    }
}
