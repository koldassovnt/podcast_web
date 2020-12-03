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
    public class ManageRolesController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManageRoles
        public ActionResult RoleList()
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<Role> roles = db.Roles;
                    var viewModel = new RoleViewModel() { Roles = roles.ToList() };
                    return View(viewModel);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult RoleList(Role role)
        {
            try
            {
                db.Roles.Add(role);
                db.SaveChanges();

                return RedirectToAction("RoleList");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<Role> roles = db.Roles;
                    Role role = new Role();

                    foreach (var r in roles.ToList())
                    {
                        if (r.RoleId == id)
                        {
                            role = r;
                            break;
                        }
                    }
                    return View(role);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }

        [Route("ManageRoles/DeleteRole/{id}")]
        public ActionResult DeleteRole(int id)
        {
            var role = db.Roles.Single(r => r.RoleId == id);
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }


    }
}