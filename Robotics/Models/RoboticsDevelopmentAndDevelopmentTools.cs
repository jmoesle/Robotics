using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsDevelopmentAndDevelopmentTools
    {
        public RoboticsDevelopmentAndDevelopmentTools()
        {
            RoboticsDevelopmentAndDevelopmentToolsTrans = new HashSet<RoboticsDevelopmentAndDevelopmentToolsTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RoboticsDevelopmentAndDevelopmentToolsTrans> RoboticsDevelopmentAndDevelopmentToolsTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
