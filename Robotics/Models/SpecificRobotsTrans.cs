using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class SpecificRobotsTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Specificrobots { get; set; }
        public int Language { get; set; }

        public virtual Languages LanguageNavigation { get; set; }
        public virtual SpecificRobots SpecificrobotsNavigation { get; set; }
    }
}
