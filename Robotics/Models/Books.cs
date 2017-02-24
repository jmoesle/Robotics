using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Books
    {
        public Books()
        {
            InfoSources = new HashSet<InfoSources>();
        }

        public int Id { get; set; }
        public string Firstnameauhor1 { get; set; }
        public string Lastnameauhor1 { get; set; }
        public string Firstnameauhor2 { get; set; }
        public string Lastnameauhor2 { get; set; }
        public string Firstnameauhor3 { get; set; }
        public string Lastnameauhor3 { get; set; }
        public string Furtherauthors { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Edition { get; set; }
        public DateTime Publicationdate { get; set; }
        public string Pages { get; set; }

        public virtual ICollection<InfoSources> InfoSources { get; set; }
    }
}
