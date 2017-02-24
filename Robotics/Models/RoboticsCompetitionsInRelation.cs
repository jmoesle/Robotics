using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompetitionsInRelation
    {
        public int Id { get; set; }
        public int Roboticscompetitions { get; set; }
        public int? Industries { get; set; }
        public int? Contributingfields { get; set; }

        public virtual ContributingFields ContributingfieldsNavigation { get; set; }
        public virtual Industries IndustriesNavigation { get; set; }
        public virtual RoboticsCompetitions RoboticscompetitionsNavigation { get; set; }
    }
}
