using System;

namespace Vote.Worker.Providers
{
    public class MessageEventArgs : EventArgs
    {
        public String Message { get; set; }
    }
}