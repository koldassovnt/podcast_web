using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{

    // : IdentityDbContext<User>
    public class PodcastLibContext : DbContext
    {

        public PodcastLibContext() : base("PodcastLibContext")
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasRequired<Company>(a => a.Company)
                .WithMany(c => c.Authors)
                .HasForeignKey<int>(a => a.CompanyID);


            modelBuilder.Entity<Podcast>()
                .HasRequired<Author>(p => p.Author)
                .WithMany(a => a.Podcasts)
                .HasForeignKey<int>(p => p.AuthorID);

            modelBuilder.Entity<Podcast>()
                .HasRequired<ProgrammingLanguage>(p => p.ProgrammingLanguage)
                .WithMany(pl => pl.Podcasts)
                .HasForeignKey<int>(p => p.ProgrammingLanguageID);

            modelBuilder.Entity<Podcast>()
                .HasMany<User>(p => p.Users)
                .WithMany(u => u.Podcasts)
                .Map(up =>
                {
                    up.MapLeftKey("PodcastID");
                    up.MapRightKey("UserID");
                    up.ToTable("UserPodcast");
                });

            modelBuilder.Entity<Podcast>()
                .HasMany<Platform>(p => p.Platforms)
                .WithMany(pl => pl.Podcasts)
                .Map(ppl =>
                {
                    ppl.MapLeftKey("PodcastID");
                    ppl.MapRightKey("PlatformId");
                    ppl.ToTable("PodcastPlatform");
                });

            modelBuilder.Entity<User>()
                .HasMany<Role>(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur => {
                    ur.MapLeftKey("UserId");
                    ur.MapRightKey("RoleId");
                    ur.ToTable("UserRole");
                });
        }

    }
}