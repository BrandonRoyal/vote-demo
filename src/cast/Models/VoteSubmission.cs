using System;
using Vote.Cast.Models;

namespace Vote.Models
{
    public class VoteSubmission
    {
         public DateTime DateTime { get; set; }
         public Candidate Candidate { get; set; }
    }
}