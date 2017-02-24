using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class SpecificRobots
    {
        public SpecificRobots()
        {
           
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
            SpecificRobotsTrans = new HashSet<SpecificRobotsTrans>();
        }

        public int Id { get; set; }
        public List<ModesOfLocomotion> Modesoflocomotion { get; set; }
        public List<RoboticsPrinciples> Roboticsprinciples { get; set; }
        public List<Industries> Industries { get; set; }
        public List<ContributingFields> Contributingfields { get; set; }
        public List<Types> Types { get; set; }
        public List<RobotComponentsAndDesignFeatures> Robotcomponentsanddesignfeatures { get; set; }
        public List<RoboticsDevelopmentAndDevelopmentTools> Roboticsdevelopmentanddevelopmenttools { get; set; }
        public List<RoboticsCompanies> Roboticscompanies { get; set; }
        public List<RoboticsOrganizations> Roboticsorganizations { get; set; }
        public List<RoboticsCompetitions> Roboticscompetitions { get; set; }
        public List<InfluentialPeople> Influentialpeople { get; set; }
        public List<DegreeOfMaturity> Degreeofmaturity { get; set; }

       public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
           public virtual ICollection<SpecificRobotsTrans> SpecificRobotsTrans { get; set; }
    }
}
