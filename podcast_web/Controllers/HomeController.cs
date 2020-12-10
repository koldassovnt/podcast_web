using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            IEnumerable<Author> authors = db.Authors;
            IEnumerable<ProgrammingLanguage> pLangs = db.ProgrammingLanguages;

            foreach (var p in podcasts.ToList())
            {
                var a = authors.Single(au => au.AuthorID == p.AuthorID);
                var pl = pLangs.Single(plang => plang.ProgrammingLanguageID == p.ProgrammingLanguageID);
                p.Author = a;
                p.ProgrammingLanguage = pl;
            }

            var viewModel = new PodcastsViewModel() { Podcasts = podcasts.ToList() };
            ViewBag.ViewModel = viewModel;

            return View();  
        }

        [HttpPost]
        public ActionResult Index(string Title)
        {

            var podcasts = db.Podcasts.Where(p => p.Title.Equals(Title));
            var viewModel = new PodcastsViewModel() { Podcasts = podcasts.ToList() };
            ViewBag.ViewModel = viewModel;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult AutocompleteSearch(string term)
        {
            var res = db.Podcasts.Where(p => p.Title.Contains(term))
                                        .Select(p => new { value = p.Title })
                                        .Distinct();
                
            return Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Error403()
        {
            return View();
        }

    }
}