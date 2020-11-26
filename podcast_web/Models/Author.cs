using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AuthorJob { get; set; }
        public string AuthorImg { get; set; }
        public ICollection<Podcast> Podcasts { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }


    }
}