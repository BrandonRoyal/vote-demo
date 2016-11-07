using System;
using Npgsql;
using Vote.Worker.Models;

namespace Vote.Worker.Providers
{
    public class PostgresProvider : IDbProvider
    {
        private NpgsqlConnection _connection;
        public void Connect(string connectionString)
        {
             _connection = new NpgsqlConnection(connectionString);
             _connection.Open();           
        }   

        public T ExecuteSqlQuery<T>(string sqlQuery)
        {
            //TODO: check for type
            NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, _connection);

            using (var dr = cmd.ExecuteReader())
            {

                var result = new PostgresResult();
                while (dr.Read())
                {
                    result.HasRows = dr.HasRows;
                    result.Value = dr.GetString(0);
                }
                return (T) Convert.ChangeType(result, typeof(T));
            }
        }
    }
}