using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    // : IdentityRole
    public class Role 
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}