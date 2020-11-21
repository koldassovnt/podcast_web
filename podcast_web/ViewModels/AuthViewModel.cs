using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using podcast_web.Models;

namespace podcast_web.ViewModels
{
    public class AuthViewModel
    {
        public List<User> Users { get; set; }
    }
}