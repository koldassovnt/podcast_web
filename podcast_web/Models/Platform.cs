using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class Platform
    {
        public Platform() => Podcasts = new HashSet<Podcast>();
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Podcast> Podcasts { get; set; }
    }
}