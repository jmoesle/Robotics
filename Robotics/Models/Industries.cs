using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Industries
    {
        public Industries()
        {
            IndustriesTrans = new HashSet<IndustriesTrans>();
            RelatedIndustriesIndustry1Navigation = new HashSet<RelatedIndustries>();
            RelatedIndustriesIndustry2Navigation = new HashSet<RelatedIndustries>();
            RoboticsCompaniesInRelation = new HashSet<RoboticsCompaniesInRelation>();
            RoboticsCompetitionsInRelation = new HashSet<RoboticsCompetitionsInRelation>();
            RoboticsOrganizationsInRelation = new HashSet<RoboticsOrganizationsInRelation>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<IndustriesTrans> IndustriesTrans { get; set; }
        public virtual ICollection<RelatedIndustries> RelatedIndustriesIndustry1Navigation { get; set; }
        public virtual ICollection<RelatedIndustries> RelatedIndustriesIndustry2Navigation { get; set; }
        public virtual ICollection<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual ICollection<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual ICollection<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
