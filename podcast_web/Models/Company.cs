using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Author> Authors { get; set; }

    }
}