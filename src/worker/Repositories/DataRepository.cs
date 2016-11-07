using System;
using Npgsql;
using Vote.Worker.Models;
using Vote.Worker.Providers;

namespace Vote.Worker.Repositories
{
    public class DataRepository : IDataRepository
    {
        private IDbProvider _dbProvider;
        public void IncrementCandidateVote(Candidate candidate)
        {
            CreateTableIfNotExist("candidate_counts"); //create table if it doesnt exist
            var result = _dbProvider.ExecuteSqlQuery<PostgresResult>(String.Format("SELECT count from candidate_counts WHERE id='{0}'", candidate.Id)); //select candidate by id
            if (!result.HasRows)
            {
                _dbProvider.ExecuteSqlQuery<PostgresResult>(String.Format("INSERT INTO {0} (id, name, count) VALUES ('{1}', '{2}', {3})", "candidate_counts", candidate.Id, candidate.Name, 1));
                return;
            }
            var count = Convert.ToInt32(result.Value) + 1; //increment id by 1
            _dbProvider.ExecuteSqlQuery<PostgresResult>(String.Format("UPDATE candidate_counts SET count={0} WHERE id='{1}'", count, candidate.Id)); //update table
        }

        public DataRepository(IDbProvider dbProvider, IConfigProvider config)
        {
            _dbProvider = dbProvider;
            _dbProvider.Connect(config.DbConnectionString);
        }

        private void CreateTableIfNotExist(String tableName)
        {
            if (!TableExists("candidate_counts"))
             {
                 CreateTable("candidate_counts");
             }
        }

        private bool TableExists(String tableName)
        {
            var query = String.Format("SELECT * FROM information_schema.tables WHERE table_name = '{0}'", tableName);
            var result = _dbProvider.ExecuteSqlQuery<PostgresResult>(query);
            return result.HasRows;
        }

        private void CreateTable(String tableName)
        {
            var query = String.Format("CREATE TABLE {0} (row_id serial primary key, id text NOT NULL, name text NOT NULL, count int NOT NULL);", tableName);
            var result = _dbProvider.ExecuteSqlQuery<PostgresResult>(query);
        }
    }
}