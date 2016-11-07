using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Vote.Worker.Providers
{
    public class RabbitMqProvider : IMessageQueueProvider
    {
        public event EventHandler<MessageEventArgs> MessageRecieved;

        protected void OnMessageRecieved(String message)
        {
            if (MessageRecieved == null)
                return;
            var args = new MessageEventArgs(){ Message = message };
            MessageRecieved(this, args);
        }

        public void Connect(String hostName, String queueName)
        {

            var factory = new ConnectionFactory() { HostName = hostName };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                OnMessageRecieved(message);
            };
            channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);

                //Thread.Sleep(60000);
            
            
            // var factory = new ConnectionFactory() { HostName = hostName };
            // using(var connection = factory.CreateConnection())
            // using(var channel = connection.CreateModel())
            // {
            //     channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            //     var consumer = new EventingBasicConsumer(channel);
            //     consumer.Received += (model, ea) =>
            //     {
            //         var body = ea.Body;
            //         var message = Encoding.UTF8.GetString(body);
            //         OnMessageRecieved(message);
            //     };
            //     channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);
            // }
        }
    }
}