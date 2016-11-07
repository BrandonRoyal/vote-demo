using System;
using Microsoft.AspNetCore.Mvc;
using Vote.Cast.Repositories;

namespace Vote.Cast.Controllers
{
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            var candidate = _repository.GetCandidate(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Json(candidate);
        }

        private ICandidateRepository _repository;
        
        public CandidatesController(ICandidateRepository repository)
        {
            _repository = repository;
        }
    }
}