using Ocean.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Domain.Repository
{
    public interface IRepository<TEntity,keyT> where TEntity : BaseEntity<keyT> 
    {
        /// <summary>
        /// 工作单元 保持事务的一致性
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        /// <summary>
        /// 新增实体，EF原生方法
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
        /// <summary>
        /// 异步新增实体,EF原生方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AsyncAdd(TEntity entity);
        /// <summary>
        /// 新增多个实体，EF原生方法
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(ICollection<TEntity> entities);
        /// <summary>
        /// 异步新增多个实体，EF原生方法
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AsyncAddRange(ICollection<TEntity> entities);

        /// <summary>
        /// 根据条件删除实体，plus方法
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<TEntity, bool>> @where);
        /// <summary>
        /// 异步根据条件删除实体，plus方法
        /// </summary>
        /// <param name="where"></param>
        Task AsyncDelete(Expression<Func<TEntity, bool>> @where);

        /// <summary>
        /// 修改实体，EF原生方法
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// 批量修改实体,EF原生方法
        /// </summary>
        /// <param name="entitys"></param>
        void UpdateRange(ICollection<TEntity> entitys);
        /// <summary>
        /// 根据条件批量修改实体，可以指定修改的属性
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <param name="updateExp">需要修改的属性</param>
        void BatchUpdate(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, TEntity>> updateExp);
        /// <summary>
        /// 异步根据条件批量修改实体，可以指定修改的属性
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <param name="updateExp">需要修改的属性</param>
        Task AsyncBatchUpdate(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, TEntity>> updateExp);

        /// <summary>
        /// 根据条件返回实体条数
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> @where = null);
        /// <summary>
        /// 异步根据条件返回实体条数
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        Task<int> AsyncCount(Expression<Func<TEntity, bool>> @where = null);
        /// <summary>
        /// 根据条件判断是否存在指定的实体
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        bool Exist(Expression<Func<TEntity, bool>> @where = null);
        /// <summary>
        /// 异步根据条件判断是否存在指定的实体
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        Task<bool> AsyncExist(Expression<Func<TEntity, bool>> @where = null);
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        TEntity GetSingle(keyT key);
        /// <summary>
        /// 获取单个实体，包含的条件
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        TEntity GetSingle(keyT key, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
        /// <summary>
        /// 异步获取单个实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> AsyncGetSingle(keyT key);
        /// <summary>
        /// 根据条件获取所有的实体，并且取消跟踪
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);

    }
}
