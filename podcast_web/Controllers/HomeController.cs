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


        public ActionResult Index()
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            var viewModel = new PodcastsViewModel() { Podcasts = podcasts.ToList() };

            return View(viewModel);  
        }

        public ActionResult About()
        {
            return View();
        }

        
    }
}