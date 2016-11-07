using Microsoft.AspNetCore.Mvc;
using Vote.Results.Repositories;

namespace Vote.Results.Controllers
{
    [Route("results/api/[controller]")]
    public class ResultsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_repo.GetResultItems());
        }

        private IResultsRepository _repo;

        public ResultsController(IResultsRepository repo)
        {
            _repo = repo;   
        }
    }
}