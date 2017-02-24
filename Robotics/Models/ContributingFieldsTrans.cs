using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class ContributingFieldsTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Contributingfields { get; set; }
        public int Language { get; set; }

        public virtual ContributingFields ContributingfieldsNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
