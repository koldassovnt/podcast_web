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
                new Company ( "Yandex", "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos."),
                new Company ( "Hooli", "Nunc laoreet, massa auctor sagittis sagittis, arcu risus sagittis dolor, ac dictum justo ligula non orci.")
            };

            var authors = new List<Author> { 
                new Author ( "Christian",  "Bale", "JS Dev", 1, "https://celebritycontacts1.com/wp-content/uploads/2020/06/Christian-Bale.jpg"),
                new Author ( "Leonardo", "Di Caprio", "PHP Dev",  2, "https://i.pinimg.com/736x/24/86/23/2486237ab32f6d2e6ae2b30e59089f9a.jpg"),
                new Author ( "Robert",  "De Niro", "C++ Dev", 2, "https://api.time.com/wp-content/uploads/2015/09/150924_ho_intern.jpg?w=600&quality=85")
            };

            var platforms = new List<Platform> { 
                new Platform ("Yandex Music"),
                new Platform ("Apple Music"),
                new Platform ("Spotify")
            };

            var prog_langs = new List<ProgrammingLanguage> { 
                new ProgrammingLanguage ( "PHP"),
                new ProgrammingLanguage ( "JS"),
                new ProgrammingLanguage ( "Kotlin"),
                new ProgrammingLanguage ( "C++"),
                new ProgrammingLanguage ( "C#"),
                new ProgrammingLanguage ( "Java"),
            };

            var podcasts = new List<Podcast> { 
                new Podcast ( "01-12-2019", "Learning JavaScript", "------",
                "https://habrastorage.org/getpro/habr/post_images/32d/97b/231/32d97b231bde5ae266cb7aef68f3f863.png",
                "Donec augue lectus, sollicitudin sit amet metus nec, posuere sagittis dui.",
                1, 2),

                new Podcast ( "17-05-2020", "PHP in use", "------",
                "https://chto-eto-takoe.ru/uryaimg/2fec392304a5c23ac138da22847f9b7c.png",
                "Maecenas faucibus dolor id ipsum hendrerit, non blandit arcu feugiat. Integer vitae diam nunc.",
                2, 1),

                new Podcast ( "21-12-2019", "C++ is not for OLD!", "------",
                "https://static10.tgstat.ru/channels/_0/ab/abfa1e2b8aaaf90abf1220dd562b7195.jpg",
                "Cras volutpat, felis a condimentum aliquam, turpis dui vehicula nisi, eu blandit elit est vitae nibh.",
                3, 4)
            };

            var roles = new List<Role>
            {
                new Role ( "ROLE_ADMIN"),
                new Role ( "ROLE_MODERATOR"),
                new Role ( "ROLE_USER")
            };

            //users.ForEach(u => db.Users.Add(u));
            companies.ForEach(c => db.Companies.Add(c));
            authors.ForEach(a => db.Authors.Add(a));
            platforms.ForEach(p => db.Platforms.Add(p));
            prog_langs.ForEach(pl => db.ProgrammingLanguages.Add(pl));
            podcasts.ForEach(pod => db.Podcasts.Add(pod));
            roles.ForEach(r => db.Roles.Add(r));

            db.SaveChanges();
        }
    }
}