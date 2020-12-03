using podcast_web.Models;
using System;
using System.Collections.Generic;
using podcast_web.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace podcast_web.Controllers
{
    public class ManageCompaniesController : Controller
    {
        // создаем контекст данных
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManageCompanies
        public ActionResult CompanyList()
        {

            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {
                    IEnumerable<Company> companies = db.Companies;
                    var viewModel = new CompanyViewModel() { Companies = companies.ToList() };

                    return View(viewModel);
                }
            }
            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult CompanyList(Company company)
        {
            try
            {
                db.Companies.Add(company);
                db.SaveChanges();

                return RedirectToAction("CompanyList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(s => s.Email == email);
                if (user != null && user.Roles.FirstOrDefault(r => r.Name == "ROLE_ADMIN") != null)
                {

                    IEnumerable<Company> companies = db.Companies;
                    Company company = new Company();

                    foreach (var c in companies.ToList())
                    {
                        if (c.CompanyID == id)
                        {
                            company = c;
                            break;
                        }
                    }
                    return View(company);
                }
            }

            return RedirectToAction("Error403", "Home", new { area = "" });

        }

        [HttpPost]
        public ActionResult EditCompany(int id, FormCollection collectiont)
        {
            try
            {
                var company = db.Companies.Single(c => c.CompanyID == id);

                if (TryUpdateModel(company))
                {
                    db.Companies.AddOrUpdate(company);
                    db.SaveChanges();
                    return RedirectToAction("CompanyList");
                }

                return View(company);
            }
            catch
            {
                return View();
            }
        }

        [Route("ManageCompanies/DeleteCompany/{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var company = db.Companies.Single(c => c.CompanyID == id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("CompanyList");
        }
    }
}