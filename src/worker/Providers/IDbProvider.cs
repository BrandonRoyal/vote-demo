using System;

namespace Vote.Worker.Providers
{
    public interface IDbProvider
    {
        void Connect(String connectionString);
        T ExecuteSqlQuery<T>(String sqlQuery);
    }
}