using System;
using System.Linq;
using System.Collections.Generic;
using Vote.Results.Models;
using Vote.Results.Providers;

namespace Vote.Results.Repositories
{
    public class ResultsRepository : IResultsRepository
    {
        public IEnumerable<ResultItem> GetResultItems()
        {
            //TODO: Select all results
            return _dbProvider.ExecuteSqlQuery<IEnumerable<ResultItem>>("SELECT * from candidate_counts");
        }

        private IDbProvider _dbProvider;

        public ResultsRepository(IDbProvider dbProvider, IConfigProvider config)
        {
            _dbProvider = dbProvider;
            _dbProvider.Connect(config.DbConnectionString);
        }
    }

    public interface IResultsRepository
    {
        IEnumerable<ResultItem> GetResultItems();
    }
}