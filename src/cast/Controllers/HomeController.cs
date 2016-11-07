using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vote.Cast.Models;
using Vote.Cast.Repositories;

namespace Vote.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Candidates = _repository.GetCandidates();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }

        private ICandidateRepository _repository;

        public HomeController(ICandidateRepository repository)
        {
            _repository = repository;
        }
    }
}