namespace EmployeeManager.Services
{
    public class BaseFilterDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 4;
    }
}