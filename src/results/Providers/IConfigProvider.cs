using System;

namespace Vote.Results.Providers
{
    public interface IConfigProvider
    {
        String DbConnectionString { get; }
    }
}