using System;

namespace Vote.Worker.Models
{
    public class PostgresResult
    {
        public bool HasRows { get; set; }
        public String Value { get; set; }
    }
}