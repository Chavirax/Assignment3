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
        private MovieListContext context { get; set; }

        //constructor
        public HomeController(MovieListContext con)
        {
            context = con;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()//Podcast  controller
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoviesApp()//Movie Application controller
        {
            return View();
        }

        [HttpPost]
        public IActionResult MoviesApp(MovieItem m)// this is the controller for the movie application once it's submitted; It will take you to the confirmation screen
        {
            if (ModelState.IsValid)
            {
                context.Movie.Add(m);
                context.SaveChanges();
            }
            return View(); // this allows the return the view and what the items in the class that were submitted.
        }

        public IActionResult Movies()//List of all movies entered controller
        {
            return View(context.Movie); //Sending the inputs from the model that we created
        }
        //controller to update the database
        public IActionResult Update(string movietitle)
        {
            //queries the database with the title
            MovieItem movie = context.Movie.Where(x => x.Title == movietitle).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Update(MovieItem movie, string movietitle)
        {
            //Changes the values of the field to what was updated
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Title = movie.Title;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Category = movie.Category;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Year = movie.Year;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Director = movie.Director;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Rating = movie.Rating;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Edited = movie.Edited; // had to convert the bool into a string
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().LentTo = movie.LentTo;
            context.Movie.Where(x => x.Title == movietitle).FirstOrDefault().Notes = movie.Notes;

            context.SaveChanges();

            return RedirectToAction("Movies");
        }

        //fuctionality to delete movies in the database
        [HttpPost]
        public IActionResult Delete(string movietitle)
        {
            MovieItem movie = context.Movie.Where(x => x.Title == movietitle).FirstOrDefault();
            context.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Movies");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
