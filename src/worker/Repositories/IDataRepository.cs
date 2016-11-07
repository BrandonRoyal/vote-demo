using Vote.Worker.Models;

namespace Vote.Worker.Repositories
{
    public interface IDataRepository
    {
        void IncrementCandidateVote(Candidate candidate);
    }
}