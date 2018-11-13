using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.DAL;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _context;

        public MoviesController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Route("movies")]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        // GET: Movie with Id
        [Route("movies/{id}")]
        public ActionResult Details(int? id)
        {
            try
            {
                var movie = _context.Movies.Include(m => m.Genre).Single(m => m.Id == id);
                return View(movie);
            }

            catch (InvalidOperationException)
            {
                Movie movie = null;
                return View(movie);
            }
        }
    }
}