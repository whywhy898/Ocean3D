using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.Dapper
{
    /// <summary>
    /// dapper多条件查询核心类
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class DapperQueryHandle<T> where T:IQueryDto
    {
        //保存初始sql语句
        public string FastSql { get; private set; }
        //保存条件过滤实体
        public T ConditionObject { get; private set;}
        //保存参数条件
        public IDictionary<string,string> ListCondit { get; private set; } =new Dictionary<string, string>();

        public DapperQueryHandle(string sql,T objectCon)
        {
            FastSql = sql;
            ConditionObject = objectCon;
        }
        /// <summary>
        /// 开发添加参数条件方法
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sqlwhere"></param>
        public void AddWHere(string key,string sqlwhere)
        {
            ListCondit.Add(key, sqlwhere);
        }
    }
}
