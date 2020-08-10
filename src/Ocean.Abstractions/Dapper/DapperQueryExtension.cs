using Dapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ocean.Application.Dapper
{
    /// <summary>
    /// dapper多条件查询拓展
    /// </summary>
    public static class DapperQueryExtension
    {
        public static DapperQueryHandle<T> AddCondition<T>(this DapperQueryHandle<T> queryHandle,Expression<Func<T,bool>> condition,string wheresql) where T:IQueryDto
        {
            if (condition.Compile()(queryHandle.ConditionObject))
            {
                var type = queryHandle.ConditionObject.GetType();
                var properName = type.GetProperties().Where(a=>wheresql.Contains(a.Name)).Select(a=>a.Name).SingleOrDefault();
                if (string.IsNullOrEmpty(properName))
                {
                    throw new Exception("无效的条件参数！");
                }

                queryHandle.AddWHere(properName, wheresql);
            }

            return queryHandle;
        }
        /// <summary>
        /// 创建参数DynamicParameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryHandle"></param>
        /// <returns></returns>
        public static (string sql, DynamicParameters parameter) Builder<T>(this DapperQueryHandle<T> queryHandle) where T : IQueryDto
        {
            var paramer = new DynamicParameters();
            var LastSql = queryHandle.FastSql;

            queryHandle.ListCondit.ToList().ForEach(a =>
            {
                var value= queryHandle.ConditionObject
                                      .GetType()
                                      .GetProperty(a.Key)
                                      .GetValue(queryHandle.ConditionObject);
                LastSql += a.Value;

                if (a.Value.Contains("like"))
                {
                    value = $"%{value}%";
                }

                paramer.Add(a.Key, value);
            });

            return (LastSql, paramer);
        }

        /// <summary>
        /// 创建带分页的参数语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryHandle"></param>
        /// <param name="orderby">排序属性</param>
        /// <returns></returns>
        public static (string sql, DynamicParameters parameter) BuilderPage<T>(this DapperQueryHandle<T> queryHandle,string orderby) where T : IQueryDto
        {
            var (sql,param)=queryHandle.Builder();

            var pageSize = queryHandle.ConditionObject.PageNum;
            var pageNum = queryHandle.ConditionObject.CurrentPage;

            var pageSql = $@"select * from (select ROW_NUMBER() over(order by {orderby}) as RowNum,* from 
                           ({sql}) as tab) as lasttab where RowNum >= ({pageNum} * {pageSize} + 1 ) 
                           AND RowNum <= ({pageNum} + 1) * {pageSize}";

            return (pageSql, param);
        }

    }
}
