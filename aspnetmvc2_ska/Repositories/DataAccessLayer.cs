using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace aspnetmvc2_ska.Repositories
{
    public class DataAccessLayer
    {
        private static readonly string ServerName = ConfigurationManager.ConnectionStrings["Data Source=(localdb)\\localDB"].ConnectionString;


        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            var sqlConnection = new SqlConnection(ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<T>(sql, param);
            }
        }

        public void Execute(string sql, object param = null)
        {
            var sqlConnection = new SqlConnection(ServerName);
            using (var conn = sqlConnection)
            {
                conn.Execute(sql, param);
            }
        }

        public int QueryReturnId(string sql, object param = null)
        {
            var sqlConnection = new SqlConnection(ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<int>(sql, param).Single();
            }
        }
    }
}