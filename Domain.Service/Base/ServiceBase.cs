using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories.Base;
using Domain.Core.Interfaces.Services.Base;

namespace Domain.Service
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryAsyncBase<TEntity> _repository;

        public ServiceBase(IRepositoryAsyncBase<TEntity> repository)
        {
            this._repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _repository.Add(entity);
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _repository.AddRange(entity);
            return entity;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public ValueTask<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.GetWhere(predicate);
        }

        public Task Remove(TEntity entity)
        {
            return _repository.Remove(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            await _repository.Update(entity);
            return entity;
        }
    }
}