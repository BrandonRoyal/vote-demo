using System.Collections.Generic;

namespace Vote.Cast.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Candidate> Candidates {get;set;}
    }
}