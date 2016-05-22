using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Web.Models;

namespace MovieSearch.Web.Controllers
{
    public class TitlesController : Controller
    {
        private TitlesContext _context;

        public TitlesController(TitlesContext context)
        {
            _context = context;
        }

        [Route("api/movies/toptenlatest")]
        public JsonResult GetTopTenLatestReleases()
        {
            var topMovies = _context.Title.ToList().OrderByDescending(x => x.ReleaseYear).Take(10);


            var movies = (from title in topMovies
                join titlegenre in _context.TitleGenre on title.TitleId equals titlegenre.TitleId
                join genre in _context.Genre on titlegenre.GenreId equals genre.Id
                select new { title.TitleName, title.ReleaseYear, genre.Name }).OrderByDescending(x => x.ReleaseYear);


            return new JsonResult(movies);
        }

        public IActionResult Index()
        {
            return View(_context.Title.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Title.Add(title);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }
    }
}
