using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RelatedContributingFields
    {
        public int Id { get; set; }
        public int Contributingfield1 { get; set; }
        public int Contributingfield2 { get; set; }

        public virtual ContributingFields Contributingfield1Navigation { get; set; }
        public virtual ContributingFields Contributingfield2Navigation { get; set; }
    }
}
