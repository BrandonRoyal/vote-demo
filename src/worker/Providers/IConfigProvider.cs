using System;

namespace Vote.Worker.Providers
{
    public interface IConfigProvider
    {
        String DbConnectionString { get; }
    }
}