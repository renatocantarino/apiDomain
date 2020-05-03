using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repositories.Base
{
    public interface IRepositoryAsyncBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);

        Task<List<TEntity>> AddRange(List<TEntity> entity);

        void Dispose();

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAll();

        ValueTask<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task Remove(TEntity entity);

        Task<TEntity> Update(TEntity entity);
    }
}