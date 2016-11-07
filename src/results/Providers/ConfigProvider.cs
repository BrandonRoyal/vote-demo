using System;

namespace Vote.Results.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        public string DbConnectionString
        {
            get
            {
                return "Server=postgres;User Id=postgres;Password=mysecretpassword;Database=postgres;";
            }
        }
    }
}