using System;
using System.Linq;
using System.Collections.Generic;
using Vote.Cast.Models;

namespace Vote.Cast.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public Candidate GetCandidate(String id)
        {
            var candidates = GetCandidates();
            return candidates.Where(x => x.Id == new Guid(id)).First();
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            var candidates = new List<Candidate>();
            candidates.Add(new Candidate(){ Name = "Cabin", Id = new Guid("734965fa-fc66-4819-a751-4219d11d27bf"), ImgPath = "img/portfolio/cabin.png"});
            candidates.Add(new Candidate(){ Name = "Cake", Id = new Guid("503cc264-2a58-4e2f-aea8-6a064d2289c1"), ImgPath = "img/portfolio/cake.png"});
            candidates.Add(new Candidate(){ Name = "Circus", Id = new Guid("cc5a4d60-db9c-498b-ba95-c0b4fefe01f1"), ImgPath = "img/portfolio/circus.png"});
            candidates.Add(new Candidate(){ Name = "Video Games", Id = new Guid("f4031338-8761-442f-8724-8abbc68d4c38"), ImgPath = "img/portfolio/game.png"});
            candidates.Add(new Candidate(){ Name = "Safe", Id = new Guid("3ba90ed7-883f-4ca7-bff1-c5d67e899805"), ImgPath = "img/portfolio/safe.png"});
            candidates.Add(new Candidate(){ Name = "Submarine", Id = new Guid("75a52877-40ae-4c2e-9852-bc3b7690aec5"), ImgPath = "img/portfolio/submarine.png"});
            return candidates;
        }
    }

    public interface ICandidateRepository
    {
        Candidate GetCandidate(String id);
        IEnumerable<Candidate> GetCandidates();
    }
}