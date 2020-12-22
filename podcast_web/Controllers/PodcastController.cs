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


            return View(viewModel);
        }

        [Route("Podcast/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            IEnumerable<Podcast> podcasts = db.Podcasts;
            IEnumerable<Author> authors = db.Authors;
            IEnumerable<ProgrammingLanguage> pLangs = db.ProgrammingLanguages;
            IEnumerable<Audio> audios = db.Audios;
            Podcast podcast = new Podcast();

            foreach (var p in podcasts.ToList())
            {
                if (p.PodcastId == id)
                {
                    podcast = p;
                    break;
                }
            }
            var a = authors.Single(au => au.AuthorID == podcast.AuthorID);
            var pl = pLangs.Single(plang => plang.ProgrammingLanguageID == podcast.ProgrammingLanguageID);
            var audio = audios.Single(aud => aud.Id == podcast.AudioId);
            podcast.Author = a;
            podcast.ProgrammingLanguage = pl;
            podcast.Audio = audio;

            return View(podcast);
        }



    }
}