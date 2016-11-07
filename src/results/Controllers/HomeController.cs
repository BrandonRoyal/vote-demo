using Microsoft.AspNetCore.Mvc;

namespace Vote.Results.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}