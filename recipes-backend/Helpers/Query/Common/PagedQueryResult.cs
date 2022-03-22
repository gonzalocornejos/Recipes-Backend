namespace recipes_backend.Helpers.Query
{
    public class PagedQueryResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public int TotalCount { get; set; }

        public decimal TotalSum { get; set; }
    }
}
