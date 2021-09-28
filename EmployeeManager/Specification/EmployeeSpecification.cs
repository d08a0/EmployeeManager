using System.Linq;
using Ardalis.Specification;
using EmployeeManager.Models;

namespace EmployeeManager.Specification
{
    public class EmployeeSpecification : Specification<Employee>
    {
        public EmployeeSpecification(EmployeeFilter filter)
        {
            if (filter.PositionId != null)
            {
                Query.Where(fk => fk.PositionId == filter.PositionId);
            }
            Query.OrderBy(k => k.Id)
                .Skip(PaginationHelper.CalculateSkip(filter.PageSize, filter.Page))
                .Take(PaginationHelper.CalculateTake(filter.PageSize));

            Query.Include(x => x.Position);


        }
    }
}