using Ardalis.Specification;

namespace EmployeeManager.Repository
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

    }
}