using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfluentialPeople
    {
        public InfluentialPeople()
        {
            InfluentialPeopleTrans = new HashSet<InfluentialPeopleTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<InfluentialPeopleTrans> InfluentialPeopleTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
