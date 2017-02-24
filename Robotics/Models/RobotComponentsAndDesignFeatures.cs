using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RobotComponentsAndDesignFeatures
    {
        public RobotComponentsAndDesignFeatures()
        {
            RobotComponentsAndDesignFeaturesTrans = new HashSet<RobotComponentsAndDesignFeaturesTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RobotComponentsAndDesignFeaturesTrans> RobotComponentsAndDesignFeaturesTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
