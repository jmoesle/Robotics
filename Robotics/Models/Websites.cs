using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Websites
    {
        public Websites()
        {
            InfoSources = new HashSet<InfoSources>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Organization { get; set; }
        public string Title { get; set; }
        public DateTime? Publicationdate { get; set; }
        public DateTime Calldate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<InfoSources> InfoSources { get; set; }
    }
}
