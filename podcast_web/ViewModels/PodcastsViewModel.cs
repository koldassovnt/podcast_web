using podcast_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.ViewModels
{
    public class PodcastsViewModel
    {
        public List<Podcast> Podcasts { get; set; }
    }
}