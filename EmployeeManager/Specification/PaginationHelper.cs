namespace EmployeeManager.Specification
{
    public class PaginationHelper
    {
        public static int DefaultPage => 1;
        public static int DefaultPageSize => 4;

        public static int CalculateTake(int pageSize)
        {
            return pageSize <= 0 ? DefaultPageSize : pageSize;
        }
        public static int CalculateSkip(int pageSize, int page)
        {
            page = page <= 0 ? DefaultPage : page;

            return CalculateTake(pageSize) * (page - 1);
        }
        public static int CalculateTake(BaseFilter pageInfo)
        {
            return CalculateTake(pageInfo.PageSize);
        }
        public static int CalculateSkip(BaseFilter baseFilter)
        {
            return CalculateSkip(baseFilter.PageSize, baseFilter.Page);
        }
    }
}