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
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<Podcast> podcasts = db.Podcasts;
                    var viewModel = new PodcastsViewModel()
                    {
                        Podcasts = podcasts.ToList(),
                    };
                    SelectList authors = new SelectList(db.Authors, "AuthorID", "Name");
                    SelectList pLangs = new SelectList(db.ProgrammingLanguages, "ProgrammingLanguageID", "Name");
                    SelectList platforms = new SelectList(db.Platforms, "PlatformId", "Name");

                    ViewBag.Podcasts = viewModel.Podcasts;
                    ViewBag.Platforms = platforms;
                    ViewBag.ProgrammingLanguages = pLangs;
                    ViewBag.Authors = authors;

                    return View();
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }


        [HttpGet]
        public ActionResult EditPodcast(int id)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    SelectList authors = new SelectList(db.Authors, "AuthorID", "Name");
                    SelectList pLangs = new SelectList(db.ProgrammingLanguages, "ProgrammingLanguageID", "Name");
                    SelectList platforms = new SelectList(db.Platforms, "PlatformId", "Name");

                    IEnumerable<Podcast> podcasts = db.Podcasts;
                    Podcast podcast = new Podcast();

                    ViewBag.Platforms = platforms;
                    ViewBag.ProgrammingLanguages = pLangs;
                    ViewBag.Authors = authors;

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
            return RedirectToAction("Error403", "Home", new { area = "" });

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