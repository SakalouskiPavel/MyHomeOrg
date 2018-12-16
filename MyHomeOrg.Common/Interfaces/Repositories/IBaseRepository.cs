using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyHomeOrg.Common.DbModels;

namespace MyHomeOrg.Common.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : Entity
    {
        Task<TEntity> GetAsync(long id);

        Task<TEntity> AddAsync(TEntity model);

        Task<TEntity> UpdateAsync(TEntity model);

        Task<TEntity> DeleteAsync(TEntity model);

        Task<TEntity> DeleteAsync(long id);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> GetAll();
    }
}