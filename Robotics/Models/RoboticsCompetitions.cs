using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompetitions
    {
        public RoboticsCompetitions()
        {
            RoboticsCompetitionsInRelation = new HashSet<RoboticsCompetitionsInRelation>();
            RoboticsCompetitionsTrans = new HashSet<RoboticsCompetitionsTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual ICollection<RoboticsCompetitionsTrans> RoboticsCompetitionsTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
