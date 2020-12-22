using System.Collections.Generic;

namespace podcast_web.Models
{
    public class Author
    {
        public Author()
        {
        }

        public Author(string name, string surname, string authorJob, int companyID, string authorImg)
        {
            Name = name;
            Surname = surname;
            AuthorJob = authorJob;
            AuthorImg = authorImg;
            CompanyID = companyID;
        }

        public Author(int Id, string name, string surname, string authorJob, int companyID, string authorImg)
        {
            AuthorID = Id;
            Name = name;
            Surname = surname;
            AuthorJob = authorJob;
            AuthorImg = authorImg;
            CompanyID = companyID;
        }
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