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
    public class ManageProgrammingLanguagesController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManageProgrammingLanguages
        public ActionResult ProgrammingLanguageList()
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<ProgrammingLanguage> pLang = db.ProgrammingLanguages;
                    var viewModel = new ProgrammingLanguageViewModel() { ProgrammingLanguages = pLang.ToList() };

                    return View(viewModel);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult ProgrammingLanguageList(ProgrammingLanguage pLang)
        {
            try
            {
                db.ProgrammingLanguages.Add(pLang);
                db.SaveChanges();

                return RedirectToAction("ProgrammingLanguageList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditProgrammingLanguage(int id)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<ProgrammingLanguage> pLangs = db.ProgrammingLanguages;
                    ProgrammingLanguage pLang = new ProgrammingLanguage();

                    foreach (var p in pLangs.ToList())
                    {
                        if (p.ProgrammingLanguageID == id)
                        {
                            pLang = p;
                            break;
                        }
                    }
                    return View(pLang);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult EditProgrammingLanguage(ProgrammingLanguage pLang)
        {
            db.Entry(pLang).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProgrammingLanguageList");
        }


        [Route("ManageProgrammingLanguages/DeleteProgrammingLanguage/{id}")]
        public ActionResult DeletePlatform(int id)
        {
            var pLang = db.ProgrammingLanguages.Single(p => p.ProgrammingLanguageID == id);
            db.ProgrammingLanguages.Remove(pLang);
            db.SaveChanges();
            return RedirectToAction("ProgrammingLanguageList");
        }
    }
}