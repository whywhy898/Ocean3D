
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.Dapper
{
    /// <summary>
    /// dapper拓展载体
    /// </summary>
   public static class DapperHandle
    {
        public static DapperQueryHandle<T> CreateQueryHandle<T>(string sql, T objectCon) where T : IQueryDto
        {
            return new DapperQueryHandle<T>(sql, objectCon);
        }

    }
}
