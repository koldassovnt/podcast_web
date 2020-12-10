using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class ProfileController : Controller
    {
        PodcastLibContext db = new PodcastLibContext();

        // GET: Profile
        public ActionResult Index()
        {
            string email = "";

            if (Session["Email"] != null)
            {
                email = Session["Email"].ToString();
            }

            var user = db.Users.FirstOrDefault(s => s.Email == email);
            var userRoles = db.Roles.Where(r => r.Users.Any(u => u.UserId == user.UserId));
            var userPodcasts = db.Podcasts.Where(p => p.Users.Any(u => u.UserId == user.UserId));

            var viewModel = new UserViewModel()
            {
                User = user,
                Roles = userRoles.ToList(),
                Podcasts = userPodcasts.ToList()
            };

            return View(viewModel);
        }

        [Route("Profile/AddUserPodcast/{id}")]
        public ActionResult AddUserPodcast(int id)
        {
            var podcast = db.Podcasts.Single(m => m.PodcastId == id);
            string email = Session["Email"].ToString();

            var user = db.Users.FirstOrDefault(s => s.Email == email);
            user.Podcasts.Add(podcast);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}