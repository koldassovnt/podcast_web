using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class ManagePlatformsController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManagePlatforms
        public ActionResult PlatformList()
        {
            IEnumerable<Platform> platforms = db.Platforms;
            var viewModel = new PlatformViewModel() { Platforms = platforms.ToList() };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult PlatformList(Platform platform)
        {
            try
            {
                db.Platforms.Add(platform);
                db.SaveChanges();

                return RedirectToAction("PlatformList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditPlatform(int id)
        {
            IEnumerable<Platform> platforms = db.Platforms;
            Platform platform = new Platform();

            foreach (var p in platforms.ToList())
            {
                if (p.PlatformId == id)
                {
                    platform = p;
                    break;
                }
            }
            return View(platform);
        }

        [HttpPost]
        public ActionResult EditPlatform(Platform platform)
        {
            db.Entry(platform).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PlatformList");
        }

        [Route("ManagePlatforms/DeletePlatform/{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var platform = db.Platforms.Single(p => p.PlatformId == id);
            db.Platforms.Remove(platform);
            db.SaveChanges();
            return RedirectToAction("PlatformList");
        }
    }
}