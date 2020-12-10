using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ocean.Domain.Repository;
using Ocean.Domain.Core.SeedWork;
using Ocean.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Ocean.Infrastructure.Repositorys
{
   public class Repository<TEntity, KeyT> : IRepository<TEntity, KeyT> where TEntity : BaseEntity<KeyT>
    {
        private readonly EFDbContext _context;
        private DbSet<TEntity> dataSet => _context.Set<TEntity>();
        public Repository(EFDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        public void Add(TEntity entity)
        {
            dataSet.Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            dataSet.AddRange(entities);
        }

        public async Task AsyncAdd(TEntity entity)
        {
           await dataSet.AddAsync(entity);
        }

        public async Task AsyncAddRange(ICollection<TEntity> entities)
        {
            await dataSet.AddRangeAsync(entities);
        }

        public async Task AsyncBatchUpdate(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> updateExp)
        {
            await dataSet.UpdateAsync(updateExp);
        }

        public async Task<int> AsyncCount(Expression<Func<TEntity, bool>> where = null)
        {
           return await dataSet.Where(where).CountAsync();
        }

        public async Task AsyncDelete(Expression<Func<TEntity, bool>> where)
        {
          await  dataSet.Where(where).DeleteAsync();
        }

        public async Task<bool> AsyncExist(Expression<Func<TEntity, bool>> where = null)
        {
            return await (where == null ? dataSet.AnyAsync() : dataSet.AnyAsync(where));
        }

        public async Task<TEntity> AsyncGetSingle(KeyT key)
        {
            return await _context.FindAsync<TEntity>(key);
        }

        public void BatchUpdate(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TEntity>> updateExp)
        {
            dataSet.Where(where).Update(updateExp);
        }

        public int Count(Expression<Func<TEntity, bool>> where = null)
        {
            return dataSet.Where(where).Count();
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            dataSet.Where(where).Delete();
        }

        public bool Exist(Expression<Func<TEntity, bool>> where = null)
        {
            return (where == null ? dataSet.Any() : dataSet.Any(where));
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            return (where == null ? dataSet : dataSet.Where(where));
        }

        public IQueryable<TEntity> GetAllAsNoTracking(Expression<Func<TEntity, bool>> where = null)
        {
            return (where == null ? dataSet.AsNoTracking() : dataSet.Where(where).AsNoTracking()); 
        }

        public TEntity GetSingle(KeyT key)
        {
            return _context.Find<TEntity>(key);
        }

        public TEntity GetSingle(KeyT key, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            if (includeFunc == null) return GetSingle(key);
            return includeFunc(dataSet.Where(m => m.Id.Equals(key))).AsNoTracking().FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            dataSet.Update(entity);
        }

        public void UpdateRange(ICollection<TEntity> entitys)
        {
            dataSet.UpdateRange(entitys);
        }

    }
}
