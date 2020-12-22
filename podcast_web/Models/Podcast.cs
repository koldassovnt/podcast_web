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

        public Podcast(string date, string title, string source, string imgSource, string description, int authorID, int programmingLanguageID)
        {
            Date = date;
            Title = title;
            Source = source;
            ImgSource = imgSource;
            Description = description;
            AuthorID = authorID;
            ProgrammingLanguageID = programmingLanguageID;
        }

        public Podcast(int Id, string date, string title, string source, string imgSource, string description, int authorID, int programmingLanguageID)
        {
            PodcastId = Id;
            Date = date;
            Title = title;
            Source = source;
            ImgSource = imgSource;
            Description = description;
            AuthorID = authorID;
            ProgrammingLanguageID = programmingLanguageID;
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
        public virtual Audio Audio { get; set; }
        public int? AudioId { get; set; }
    }
}