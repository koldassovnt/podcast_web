using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class PodcastController : Controller
    {
        PodcastLibContext db = new PodcastLibContext();

        // GET: Podcast/All
        public ActionResult All()
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            var viewModel = new PodcastsViewModel() { Podcasts = podcasts.ToList() };


            return View(viewModel);
        }

        [Route("Podcast/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            Podcast podcast = new Podcast();

            foreach (var p in podcasts.ToList())
            {
                if (p.PodcastId == id)
                {
                    podcast = p;
                    break;
                }
            }

            return View(podcast);
        }

    }
}