using podcast_web.Models;
using podcast_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace podcast_web.Controllers
{
    public class AuthorController : Controller
    {
        PodcastLibContext db = new PodcastLibContext();


        // GET: Author/Authors
        public ActionResult Authors()
        {
            IEnumerable<Author> authors = db.Authors;
            var viewModel = new AuthorViewModel() { Authors = authors.ToList() };

            return View(viewModel);
        }

        [Route("Author/Detail/{id}")]
        public ActionResult Detail(int id)
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

            return View(author);
        }
    }
}