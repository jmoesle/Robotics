using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompaniesInRelation
    {
        public int Id { get; set; }
        public int Roboticscompanies { get; set; }
        public int? Industries { get; set; }
        public int? Contributingfields { get; set; }

        public virtual ContributingFields ContributingfieldsNavigation { get; set; }
        public virtual Industries IndustriesNavigation { get; set; }
        public virtual RoboticsCompanies RoboticscompaniesNavigation { get; set; }
    }
}
