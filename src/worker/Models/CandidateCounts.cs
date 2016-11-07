using System;

namespace Vote.Worker.Models
{
    public class CandidateCounts
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Int32 Count { get; set; }
    }
}