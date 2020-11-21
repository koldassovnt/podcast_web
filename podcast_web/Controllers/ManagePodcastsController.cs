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
    public class ManagePodcastsController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManagePodcasts
        public ActionResult PodcastList()
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            var viewModel = new PodcastsViewModel() { Podcasts = podcasts.ToList() };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult EditPodcast(int id)
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

        [HttpPost]
        public ActionResult EditPodcast(int id, FormCollection collectiont)
        {

            try
            {
                var podcast = db.Podcasts.Single(m => m.PodcastId == id);
                if (TryUpdateModel(podcast))
                {
                    db.Podcasts.AddOrUpdate(podcast);
                    db.SaveChanges();
                    return RedirectToAction("PodcastList");
                }
                return View(podcast);
            }
            catch
            {
                return View();
            }
        }

        [Route("ManagePodcasts/DeletePodcast/{id}")]
        public ActionResult DeletePodcast(int id)
        {
            var podcast = db.Podcasts.Single(m => m.PodcastId == id);
            db.Podcasts.Remove(podcast);
            db.SaveChanges();
            return RedirectToAction("PodcastList");
        }


        [HttpPost]
        public ActionResult PodcastList(Podcast podcast)
        {
            try
            {
                db.Podcasts.Add(podcast);
                db.SaveChanges();

                return RedirectToAction("PodcastList");
            }
            catch
            {
                return View();
            }
        }
    }
}