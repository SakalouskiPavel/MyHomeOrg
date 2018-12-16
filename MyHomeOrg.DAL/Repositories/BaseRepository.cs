using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MyHomeOrg.Common.DbModels;
using MyHomeOrg.Common.Interfaces.Repositories;

namespace MyHomeOrg.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        public BaseRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        public async Task<TEntity> GetAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            var result = await this._dbSet.SingleOrDefaultAsync(entity => entity.Id == id).ConfigureAwait(false);

            return result;
        }

        public async Task<TEntity> AddAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var result = this._dbSet.Add(model);
            await this._context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var entity = await GetAsync(model.Id);
            entity = Mapper.Map(model, entity);
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var result = this._dbSet.Remove(model);
            await this._context.SaveChangesAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<TEntity> DeleteAsync(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            var entity = await GetAsync(id).ConfigureAwait(false);

            var result = await DeleteAsync(entity).ConfigureAwait(false);

            return result;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException();
            }

            var result = await this._dbSet.Where(filter).ToListAsync().ConfigureAwait(false);

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var result = await this._dbSet.ToListAsync().ConfigureAwait(false);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="flag"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool flag)
        {
            if (_disposed)
            {
                return;
            }

            this._context.Dispose();
            _disposed = true;

            if (flag)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}