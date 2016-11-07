using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Vote.Cast.Models;
using Vote.Models;

namespace Vote.Cast.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        public void CastVote(Candidate candidate)
        {
            var vote = new VoteSubmission(){
                DateTime = DateTime.Now,
                Candidate = candidate
            };
            var hostName = "queue";
            var factory = new ConnectionFactory() { HostName = hostName };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "vote", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var message = JsonConvert.SerializeObject(vote);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "vote", basicProperties: null, body: body);
                }
            }
        }
    }

    public interface IVoteRepository
    {
        void CastVote(Candidate candidate);
    }
}