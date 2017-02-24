using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompaniesTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Roboticscompanies { get; set; }
        public int Language { get; set; }

        public virtual Languages LanguageNavigation { get; set; }
        public virtual RoboticsCompanies RoboticscompaniesNavigation { get; set; }
    }
}
