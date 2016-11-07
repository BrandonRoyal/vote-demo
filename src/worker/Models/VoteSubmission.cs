using System;
using Vote.Worker.Models;

namespace Vote.Worker.Models
{
    public class VoteSubmission
    {
        public DateTime DateTime { get; set; }
        public Candidate Candidate { get; set; }
    }
}