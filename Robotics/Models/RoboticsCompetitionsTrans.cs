using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsCompetitionsTrans
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Roboticscompetitions { get; set; }
        public int Language { get; set; }

        public virtual Languages LanguageNavigation { get; set; }
        public virtual RoboticsCompetitions RoboticscompetitionsNavigation { get; set; }
    }
}
