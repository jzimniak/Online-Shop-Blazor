using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName  = "default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Config { get; }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new  SqlConnection(connectionstring))
            {
                 var data = await connection.QueryAsync<T>(sql,parameters);

                return data.ToList();
            }            
        }
        public async Task Update<T>(string sql, T parameters)
        {
            string connectionstring = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionstring))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
