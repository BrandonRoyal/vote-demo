using System;

namespace Vote.Results.Providers
{
    public interface IDbProvider
    {
        void Connect(String connectionString);
        T ExecuteSqlQuery<T>(String sqlQuery);
    }
}