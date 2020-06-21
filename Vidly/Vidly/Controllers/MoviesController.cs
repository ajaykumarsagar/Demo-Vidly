using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //[Authorize(Roles = "CanManageMovie")]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }
        public ActionResult Create(Movie movie)
        {
           // var movieNDb = _context.Movies();



            if (movie.Id == 0)
            {
                 movie.DataAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDb = _context.Movies.Single(c => c.Id == movie.Id);
                //TryUpdateModel(customerDb,"",new string[] { "Name","Email"});
                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            //if (User.IsInRole("CanManageMovie"))
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List",movies);
                else
           return View("Index",movies);
      
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("NewMovie", viewModel);
        }
        // GET: Random
        public ActionResult Random()
        {

            //var movie = new Movie() { Name = "Shrek!" };

            //ViewData["Movie"] = movie;
            //ViewBag.RandomMovie = movie;

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model

            //var customers = new List<Customer>
            //{
            //    new Customer
            //    {
            //        Name="Customer 1"
            //    },
            //      new Customer
            //    {
            //        Name="Customer 2"
            //    }
            //};
            //var viewModel = new RandomMovieViewModel
            //{
            //    Movie=movie,
            //    Customers=customers
            //};

            return View();
        }
    }
}