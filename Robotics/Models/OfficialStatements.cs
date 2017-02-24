using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class OfficialStatements
    {
        public OfficialStatements()
        {
            InfoSources = new HashSet<InfoSources>();
        }

        public int Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public string Publication { get; set; }
        public string Issue { get; set; }
        public string Location { get; set; }
        public DateTime Publicationdate { get; set; }
        public string Pages { get; set; }

        public virtual ICollection<InfoSources> InfoSources { get; set; }
    }
}
