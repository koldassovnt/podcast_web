using podcast_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Podcast> Podcasts { get; set; }
    }
}