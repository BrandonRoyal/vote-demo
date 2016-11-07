using Microsoft.AspNetCore.Mvc;

namespace Vote.Cast.Controllers
{
    public class ThanksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}