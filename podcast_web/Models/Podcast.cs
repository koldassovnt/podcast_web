using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class Podcast
    {
        public Podcast()
        {
            Users = new HashSet<User>();
            Platforms = new HashSet<Platform>();
        }

        public int PodcastId { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string ImgSource { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Platform> Platforms { get; set; }
        public int ProgrammingLanguageID { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }

    }
}