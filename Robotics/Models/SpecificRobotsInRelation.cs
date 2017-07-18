using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class SpecificRobotsInRelation
    {
        public int Id { get; set; }
        public int Specificrobots { get; set; }
        public int? Modesoflocomotion { get; set; }
        public int? Roboticsprinciples { get; set; }
        public int? Branches { get; set; }
        public int? Contributingfields { get; set; }
        public int? Types { get; set; }
        public int? Robotcomponentsanddesignfeatures { get; set; }
        public int? Roboticsdevelopmentanddevelopmenttools { get; set; }
        public int? Roboticscompanies { get; set; }
        public int? Roboticsorganizations { get; set; }
        public int? Roboticscompetitions { get; set; }
        public int? Influentialpeople { get; set; }
        public int? Degreeofmaturity { get; set; }

        public virtual ContributingFields ContributingfieldsNavigation { get; set; }
        public virtual DegreeOfMaturity DegreeofmaturityNavigation { get; set; }
        public virtual Branches BranchesNavigation { get; set; }
        public virtual InfluentialPeople InfluentialpeopleNavigation { get; set; }
        public virtual ModesOfLocomotion ModesoflocomotionNavigation { get; set; }
        public virtual RobotComponentsAndDesignFeatures RobotcomponentsanddesignfeaturesNavigation { get; set; }
        public virtual RoboticsCompanies RoboticscompaniesNavigation { get; set; }
        public virtual RoboticsCompetitions RoboticscompetitionsNavigation { get; set; }
        public virtual RoboticsDevelopmentAndDevelopmentTools RoboticsdevelopmentanddevelopmenttoolsNavigation { get; set; }
        public virtual RoboticsOrganizations RoboticsorganizationsNavigation { get; set; }
        public virtual RoboticsPrinciples RoboticsprinciplesNavigation { get; set; }
        public virtual SpecificRobots SpecificrobotsNavigation { get; set; }
        public virtual Types TypesNavigation { get; set; }
    }
}
