using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Core.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public abstract class RepositoryAsyncBase<TC,TEntity> : IDisposable, IRepositoryAsyncBase<TEntity> where  TEntity: class
    where TC: DbContext , new()
    {
        private TC _context { get; set; } = new TC();

        public ValueTask<TEntity> GetById(int id) =>  _context.Set<TEntity>().FindAsync(id);

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _context.Set<TEntity>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public Task Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}