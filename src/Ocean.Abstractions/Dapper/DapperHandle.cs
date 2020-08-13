
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ocean.Application.Dapper
{
    /// <summary>
    /// dapper拓展载体
    /// </summary>
   public static class DapperHandle
    {
        private static IConfiguration configuration =null;

        public static DapperQueryHandle<T> CreateQueryHandle<T>(string sql, T objectCon) where T : IQueryDto
        {
            return new DapperQueryHandle<T>(sql, objectCon);
        }


        public static SqlConnection OpenConnection()
        {
            if (configuration == null)
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                configuration = config.Build();
            }
            var connectionStr = configuration.GetConnectionString("MsSqlServer");
            var sqlConnection = new SqlConnection(connectionStr);
            return sqlConnection;
        }

    }
}
