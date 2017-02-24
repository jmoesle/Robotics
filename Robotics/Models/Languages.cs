using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Languages
    {
        public Languages()
        {
            ContributingFieldsTrans = new HashSet<ContributingFieldsTrans>();
            CountriesTrans = new HashSet<CountriesTrans>();
            DegreeOfMaturityTrans = new HashSet<DegreeOfMaturityTrans>();
            IndustriesTrans = new HashSet<IndustriesTrans>();
            InfluentialPeopleTrans = new HashSet<InfluentialPeopleTrans>();
            ModesOfLocomotionTrans = new HashSet<ModesOfLocomotionTrans>();
            RobotComponentsAndDesignFeaturesTrans = new HashSet<RobotComponentsAndDesignFeaturesTrans>();
            RoboticsCompaniesTrans = new HashSet<RoboticsCompaniesTrans>();
            RoboticsCompetitionsTrans = new HashSet<RoboticsCompetitionsTrans>();
            RoboticsDevelopmentAndDevelopmentToolsTrans = new HashSet<RoboticsDevelopmentAndDevelopmentToolsTrans>();
            RoboticsOrganizationsTrans = new HashSet<RoboticsOrganizationsTrans>();
            RoboticsPrinciplesTrans = new HashSet<RoboticsPrinciplesTrans>();
            SpecificRobotsTrans = new HashSet<SpecificRobotsTrans>();
            TypesTrans = new HashSet<TypesTrans>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<ContributingFieldsTrans> ContributingFieldsTrans { get; set; }
        public virtual ICollection<CountriesTrans> CountriesTrans { get; set; }
        public virtual ICollection<DegreeOfMaturityTrans> DegreeOfMaturityTrans { get; set; }
        public virtual ICollection<IndustriesTrans> IndustriesTrans { get; set; }
        public virtual ICollection<InfluentialPeopleTrans> InfluentialPeopleTrans { get; set; }
        public virtual ICollection<ModesOfLocomotionTrans> ModesOfLocomotionTrans { get; set; }
        public virtual ICollection<RobotComponentsAndDesignFeaturesTrans> RobotComponentsAndDesignFeaturesTrans { get; set; }
        public virtual ICollection<RoboticsCompaniesTrans> RoboticsCompaniesTrans { get; set; }
        public virtual ICollection<RoboticsCompetitionsTrans> RoboticsCompetitionsTrans { get; set; }
        public virtual ICollection<RoboticsDevelopmentAndDevelopmentToolsTrans> RoboticsDevelopmentAndDevelopmentToolsTrans { get; set; }
        public virtual ICollection<RoboticsOrganizationsTrans> RoboticsOrganizationsTrans { get; set; }
        public virtual ICollection<RoboticsPrinciplesTrans> RoboticsPrinciplesTrans { get; set; }
        public virtual ICollection<SpecificRobotsTrans> SpecificRobotsTrans { get; set; }
        public virtual ICollection<TypesTrans> TypesTrans { get; set; }
    }
}
