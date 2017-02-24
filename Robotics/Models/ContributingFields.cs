using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class ContributingFields
    {
        public ContributingFields()
        {
            ContributingFieldsTrans = new HashSet<ContributingFieldsTrans>();
            RelatedContributingFieldsContributingfield1Navigation = new HashSet<RelatedContributingFields>();
            RelatedContributingFieldsContributingfield2Navigation = new HashSet<RelatedContributingFields>();
            RoboticsCompaniesInRelation = new HashSet<RoboticsCompaniesInRelation>();
            RoboticsCompetitionsInRelation = new HashSet<RoboticsCompetitionsInRelation>();
            RoboticsOrganizationsInRelation = new HashSet<RoboticsOrganizationsInRelation>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<ContributingFieldsTrans> ContributingFieldsTrans { get; set; }
        public virtual ICollection<RelatedContributingFields> RelatedContributingFieldsContributingfield1Navigation { get; set; }
        public virtual ICollection<RelatedContributingFields> RelatedContributingFieldsContributingfield2Navigation { get; set; }
        public virtual ICollection<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual ICollection<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual ICollection<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
