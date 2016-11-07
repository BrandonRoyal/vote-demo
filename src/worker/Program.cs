using System;
using System.Threading;
using Newtonsoft.Json;
using Vote.Worker.Models;
using Vote.Worker.Providers;
using Vote.Worker.Repositories;

namespace Vote.Worker
{
    public class Program
    {
        private static IConfigProvider _config;
        private static IMessageQueueProvider _queue;
        private static IDbProvider _db;
        private static IDataRepository _dataRepo;
        

        public static void Main(string[] args)
        {
            Init();
            Console.WriteLine("Starting Worker");
            

            _queue.MessageRecieved += (sender, e) => 
            {
                Console.WriteLine(" [x] Received {0}", e.Message);
                var voteSubmission = JsonConvert.DeserializeObject<VoteSubmission>(e.Message);
                _dataRepo.IncrementCandidateVote(voteSubmission.Candidate);
            };
            _queue.Connect("queue", "vote"); //TODO: get from config
            
            Thread.Sleep(60000);
            Console.WriteLine("Ending Worker");
        }

        public static void Init()
        {
            Bootstrap.Start();
            _config = Bootstrap.Container.GetInstance<IConfigProvider>();
            _queue = Bootstrap.Container.GetInstance<IMessageQueueProvider>();
            _db = Bootstrap.Container.GetInstance<IDbProvider>();
            _dataRepo = Bootstrap.Container.GetInstance<IDataRepository>();
        }
    }
}
