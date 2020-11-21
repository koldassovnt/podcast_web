using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
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

            IEnumerable<Author> authors = db.Authors;
            var viewModel = new AuthorViewModel() { Authors = authors.ToList() };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditAuthor(int id, FormCollection collectiont)
        {

             return View();

        }

        [Route("ManageAuthors/DeleteAuthor/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            return View();
        }
    }
}