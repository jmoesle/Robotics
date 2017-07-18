using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Branches
    {
        public Branches()
        {
            BranchesTrans = new HashSet<BranchesTrans>();
            RelatedBranchesIndustry1Navigation = new HashSet<RelatedBranches>();
            RelatedBranchesIndustry2Navigation = new HashSet<RelatedBranches>();
            RoboticsCompaniesInRelation = new HashSet<RoboticsCompaniesInRelation>();
            RoboticsCompetitionsInRelation = new HashSet<RoboticsCompetitionsInRelation>();
            RoboticsOrganizationsInRelation = new HashSet<RoboticsOrganizationsInRelation>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<BranchesTrans> BranchesTrans { get; set; }
        public virtual ICollection<RelatedBranches> RelatedBranchesIndustry1Navigation { get; set; }
        public virtual ICollection<RelatedBranches> RelatedBranchesIndustry2Navigation { get; set; }
        public virtual ICollection<RoboticsCompaniesInRelation> RoboticsCompaniesInRelation { get; set; }
        public virtual ICollection<RoboticsCompetitionsInRelation> RoboticsCompetitionsInRelation { get; set; }
        public virtual ICollection<RoboticsOrganizationsInRelation> RoboticsOrganizationsInRelation { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
