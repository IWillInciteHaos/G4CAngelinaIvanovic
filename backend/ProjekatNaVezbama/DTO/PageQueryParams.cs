namespace ProjekatNaVezbama.DTO
{
    public class PageQueryParams
    {
        public int PageSize { get; set; }
        public string PageIndeex { get; set; }


        public PageQueryParams(int pageSize, string pageIndeex)
        {
            PageSize = pageSize > 10 ? 10 :
                pageSize < 1 ? 1 :
                pageSize;
            PageIndeex = pageIndeex;
        }
    }
}
