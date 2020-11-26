using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class ManageUsersController : Controller
    {

        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();
        // GET: ManageUsers
        public ActionResult UserList()
        {
            IEnumerable<User> users = db.Users;
            var viewModel = new AuthViewModel() { Users = users.ToList() };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UserList(Platform platform)
        {

            return RedirectToAction("UserList");

        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            IEnumerable<User> users = db.Users;
            User user = new User();

            foreach (var u in users.ToList())
            {
                if (u.UserId == id)
                {
                    user = u;
                    break;
                }
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        [Route("ManageUsers/DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Single(u => u.UserId == id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }
    }
}