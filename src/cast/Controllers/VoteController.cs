using Microsoft.AspNetCore.Mvc;
using Vote.Cast.Models;
using Vote.Cast.Repositories;

namespace Vote.Cast.Controllers
{
    [Route("api/[controller]")]
    public class VoteController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Candidate candidate)
        {
            _repository.CastVote(candidate);
            return Ok();
        }

        private IVoteRepository _repository;
        public VoteController(IVoteRepository repository)
        {
            _repository = repository;
        }
    }
}