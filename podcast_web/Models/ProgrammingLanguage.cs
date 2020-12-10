using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
        }

        public ProgrammingLanguage(string name)
        {
            Name = name;
        }

        public int ProgrammingLanguageID { get; set; }
        public string Name { get; set; }
        public ICollection<Podcast> Podcasts { get; set; }
    }
}