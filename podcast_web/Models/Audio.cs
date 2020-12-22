using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podcast_web.Models
{
    public class Audio
    {
        public Audio() { }

        public Audio(string name, int? fileSize, string filePath)
        {
            Name = name;
            FileSize = fileSize;
            FilePath = filePath;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
        public virtual Podcast Podcast { get; set; }
    }
}