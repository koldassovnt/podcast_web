using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    // : IdentityRole
    public class Role 
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }

        public Role(int Id, string name)
        {
            RoleId = Id;
            Name = name;
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}