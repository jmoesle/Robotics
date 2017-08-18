using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfoTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InfoSourcesInRelation> InfoSourcesInRelation { get; set; }

    }
}
