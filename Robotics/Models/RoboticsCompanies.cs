using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompanies
    {
        public RoboticsCompanies()
        {
            RoboticsCompaniesInRelation = new HashSet<RoboticsCompaniesInRelation>();
            RoboticsCompaniesTrans = new HashSet<RoboticsCompaniesTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual ICollection<RoboticsCompaniesTrans> RoboticsCompaniesTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
