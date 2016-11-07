using System;
using System.Collections.Generic;
using Npgsql;
using Vote.Results.Models;

namespace Vote.Results.Providers
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
                if (typeof(T) == typeof(IEnumerable<ResultItem>))
                {
                    return (T) GetResultItems(dr);
                }
                throw new Exception("type not supported");
            }
        }

        private int GetInt(NpgsqlDataReader dr)
        {
            return dr.GetInt32(0);
        }

        private IEnumerable<ResultItem> GetResultItems(NpgsqlDataReader dr)
        {
            if (dr == null || !dr.HasRows) return null;
            var results = new List<ResultItem>();
            while(dr.Read())
            {
                var result = new ResultItem();
                result.Label = dr.GetString(2);
                result.Value = dr.GetInt32(3);
                results.Add(result);
            }
            return results;
        }
    }
}