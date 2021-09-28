using Ardalis.Specification.EntityFrameworkCore;
using EmployeeManager.Db;

namespace EmployeeManager.Repository
{
    public class EFRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class
    {
        private EmployeeManagerDbContext _dbContext;
        public EFRepository(EmployeeManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}