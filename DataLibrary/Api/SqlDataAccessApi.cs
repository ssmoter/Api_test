using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Api
{
    public class SqlDataAccessApi
    {
        // Klasa pod Api //
        public string ConnectionStringName { get; set; }

        public async Task<List<T>> LoadDataList<T>(string sql )
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStringName))
            {
                var data = await connection.QueryAsync<T>(sql);
                return data.ToList();
            }
        }

        public async Task<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionStringName))
            {
                var data = await connection.QuerySingleAsync<T>(sql);
                return (T)data;
            }
        }

        public async Task SaveData<T>(string sql, T parametrs )
        {
            using(IDbConnection connection = new SqlConnection(ConnectionStringName))
            {
                await connection.ExecuteAsync(sql,parametrs);
            }
        }
    }
}
