using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                    ViewBag.Users = viewModel.Users;

                    return View();
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult UserList(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();

                    AddOrUpdateUser(_user, db.Roles);
                    return RedirectToAction("UserList");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
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


        //create a string MD5
        private static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        private void AddOrUpdateUser(User user, IEnumerable<Role> roles)
        {
            var role = roles.FirstOrDefault(r => r.Name == "ROLE_USER");
            if (role == null)
            {
                role = new Role("ROLE_USER");
                db.Roles.Add(role);
            }
            user.Roles.Add(role);
            db.SaveChanges();
        }
    }
}