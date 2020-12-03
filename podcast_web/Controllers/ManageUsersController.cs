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
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<User> users = db.Users;
                    var viewModel = new AuthViewModel() { Users = users.ToList() };

                    return View(viewModel);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult UserList(Platform platform)
        {

            return RedirectToAction("UserList");

        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<User> users = db.Users;
                    User _user = new User();

                    foreach (var u in users.ToList())
                    {
                        if (u.UserId == id)
                        {
                            _user = u;
                            break;
                        }
                    }
                    return View(_user);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

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