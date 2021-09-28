using System.Linq;
using Ardalis.Specification;
using EmployeeManager.Models;

namespace EmployeeManager.Specification
{
    public class EmployeeByIdSpecification : Specification<Employee>, ISingleResultSpecification
    {
        public EmployeeByIdSpecification(int id)
        {
            Query.Where(e => e.Id == id)
                .Include(e => e.Position)
                .AsNoTracking();
        }
    }
}