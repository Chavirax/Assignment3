using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoviesApp()//Movie Application controller
        {
            return View();
        }

        public IActionResult MyPodcasts()//Podcast  controller
        {
            return View();
        }

        [HttpPost]
        public IActionResult MoviesApp(ApplicationResponse appResponse)// this is the controller for the movie application once it's submitted; It will take you to the confirmation screen
        {
            MovieList.AddApplication(appResponse);
            return View("Confirmation", appResponse); // this allows the return the view and what the items in the class that were submitted.
        }

        public IActionResult Movies()//List of all movies entered controller
        {
            return View(MovieList.Application); //Sending the inputs from the model that we created
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
