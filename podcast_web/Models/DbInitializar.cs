using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace podcast_web.Models
{
    public class DbInitializar : DropCreateDatabaseIfModelChanges<PodcastLibContext>
    {
        protected override void Seed(PodcastLibContext db)
        {

            var companies = new List<Company> {
                new Company { CompanyID = 1, Name = "Yandex", Description ="Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos."},
                new Company { CompanyID = 2, Name = "Hooli", Description = "Nunc laoreet, massa auctor sagittis sagittis, arcu risus sagittis dolor, ac dictum justo ligula non orci."}
            };

            var authors = new List<Author> { 
                new Author {AuthorID = 1, Name = "Christian", Surname = "Bale", AuthorJob = "JS Dev", CompanyID = 1},
                new Author {AuthorID = 2, Name = "Leonardo", Surname = "Di Caprio", AuthorJob = "PHP Dev", CompanyID = 2},
                new Author {AuthorID = 3, Name = "Robert", Surname = "De Niro", AuthorJob = "C++ Dev", CompanyID = 2}
            };

            var platforms = new List<Platform> { 
                new Platform {PlatformId = 1, Name = "Yandex Music"},
                new Platform {PlatformId = 2, Name = "Apple Music"},
                new Platform {PlatformId = 3, Name = "Spotify"}
            };

            var prog_langs = new List<ProgrammingLanguage> { 
                new ProgrammingLanguage {ProgrammingLanguageID = 1, Name = "PHP"},
                new ProgrammingLanguage {ProgrammingLanguageID = 2, Name = "JS"},
                new ProgrammingLanguage {ProgrammingLanguageID = 3, Name = "Kotlin"},
                new ProgrammingLanguage {ProgrammingLanguageID = 4, Name = "C++"},
                new ProgrammingLanguage {ProgrammingLanguageID = 5, Name = "C#"},
                new ProgrammingLanguage {ProgrammingLanguageID = 6, Name = "Java"},
            };

            var podcasts = new List<Podcast> { 
                new Podcast {PodcastId = 1, Date = "01-12-2019", Title = "Learning JavaScript", Source = "------",
                ImgSource="https://habrastorage.org/getpro/habr/post_images/32d/97b/231/32d97b231bde5ae266cb7aef68f3f863.png",
                Description="Donec augue lectus, sollicitudin sit amet metus nec, posuere sagittis dui.",
                AuthorID = 1, ProgrammingLanguageID = 2},

                new Podcast {PodcastId = 2, Date = "17-05-2020", Title = "PHP in use", Source = "------",
                ImgSource="https://chto-eto-takoe.ru/uryaimg/2fec392304a5c23ac138da22847f9b7c.png",
                Description="Maecenas faucibus dolor id ipsum hendrerit, non blandit arcu feugiat. Integer vitae diam nunc.",
                AuthorID = 2, ProgrammingLanguageID = 1},

                new Podcast {PodcastId = 3, Date = "21-12-2019", Title = "C++ is not for OLD!", Source = "------",
                ImgSource="https://static10.tgstat.ru/channels/_0/ab/abfa1e2b8aaaf90abf1220dd562b7195.jpg",
                Description="Cras volutpat, felis a condimentum aliquam, turpis dui vehicula nisi, eu blandit elit est vitae nibh.",
                AuthorID = 3, ProgrammingLanguageID = 4}
            };

            //users.ForEach(u => db.Users.Add(u));
            companies.ForEach(c => db.Companies.Add(c));
            authors.ForEach(a => db.Authors.Add(a));
            platforms.ForEach(p => db.Platforms.Add(p));
            prog_langs.ForEach(pl => db.ProgrammingLanguages.Add(pl));
            podcasts.ForEach(pod => db.Podcasts.Add(pod));

            db.SaveChanges();
        }
    }
}