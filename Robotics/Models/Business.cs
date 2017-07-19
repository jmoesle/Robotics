using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Business
    {
        public Business()
        {
            BusinessTrans = new HashSet<BusinessTrans>();
            RelatedBusinessBusiness1Navigation = new HashSet<RelatedBusiness>();
            RelatedBusinessBusiness2Navigation = new HashSet<RelatedBusiness>();
            RoboticsCompaniesInRelation = new HashSet<RoboticsCompaniesInRelation>();
            RoboticsCompetitionsInRelation = new HashSet<RoboticsCompetitionsInRelation>();
            RoboticsOrganizationsInRelation = new HashSet<RoboticsOrganizationsInRelation>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<BusinessTrans> BusinessTrans { get; set; }
        public virtual ICollection<RelatedBusiness> RelatedBusinessBusiness1Navigation { get; set; }
        public virtual ICollection<RelatedBusiness> RelatedBusinessBusiness2Navigation { get; set; }
        public virtual ICollection<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual ICollection<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual ICollection<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
