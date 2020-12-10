using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using podcast_web.Models;
using System.Text;

namespace podcast_web.Controllers
{
    public class AuthController : Controller
    {
        PodcastLibContext db = new PodcastLibContext();


        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
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

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
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
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Name + " " + data.FirstOrDefault().Surname;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home", new { area = "" });
        }



        //create a string MD5
        public static string GetMD5(string str)
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

        public JsonResult IsUserNameAvailable(string UserName)
        {
            return Json(!db.Users.Any(u => u.Email == UserName), JsonRequestBehavior.AllowGet);
        }
    }
}