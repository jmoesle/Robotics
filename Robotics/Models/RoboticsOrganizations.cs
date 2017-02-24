using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsOrganizations
    {
        public RoboticsOrganizations()
        {
            RoboticsOrganizationsInRelation = new HashSet<RoboticsOrganizationsInRelation>();
            RoboticsOrganizationsTrans = new HashSet<RoboticsOrganizationsTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual ICollection<RoboticsOrganizationsTrans> RoboticsOrganizationsTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
