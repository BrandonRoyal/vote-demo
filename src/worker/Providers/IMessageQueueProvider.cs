using System;

namespace Vote.Worker.Providers
{
    public interface IMessageQueueProvider
    {
        void Connect(String hostName, String queueName);
        event EventHandler<MessageEventArgs> MessageRecieved;
    }
}