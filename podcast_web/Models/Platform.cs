using System.Collections.Generic;

namespace podcast_web.Models
{
    public class Platform
    {

        public Platform() => Podcasts = new HashSet<Podcast>();

        public Platform(string name)
        {
            Name = name;
        }

        public int PlatformId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Podcast> Podcasts { get; set; }
    }
}