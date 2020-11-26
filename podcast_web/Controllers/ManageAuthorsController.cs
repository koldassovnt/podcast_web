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
    public class ManageAuthorsController : Controller
    {
        PodcastLibContext db = new PodcastLibContext();

        // GET: ManageAuthors
        public ActionResult AuthorList()
        {

         
            //IEnumerable<Company> companies = db.Companies;
            IEnumerable<Author> authors = db.Authors;
            var viewModel = new AuthorViewModel() { Authors = authors.ToList()};

            // Формируем список команд для передачи в представление
            SelectList companies = new SelectList(db.Companies, "CompanyID", "Name");
            ViewBag.Companies = companies;
            ViewBag.Authors = viewModel.Authors;

            return View();
        }

        [HttpPost]
        public ActionResult AuthorList(Author author)
        {
            try
            {
                db.Authors.Add(author);
                db.SaveChanges();

                return RedirectToAction("AuthorList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            IEnumerable<Author> authors = db.Authors;
            Author author = new Author();


            foreach (var a in authors.ToList())
            {
                if (a.AuthorID == id)
                {
                    author = a;
                    break;
                }
            }
            // Формируем список команд для передачи в представление
            SelectList companies = new SelectList(db.Companies, "CompanyID", "Name");
            ViewBag.Companies = companies;

            return View(author);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AuthorList");
        }

        [Route("ManageAuthors/DeleteAuthor/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.Authors.Single(a => a.AuthorID == id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("AuthorList");
        }
    }
}