using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RelatedBranches
    {
        public int Id { get; set; }
        public int Industry1 { get; set; }
        public int Industry2 { get; set; }

        public virtual Branches Industry1Navigation { get; set; }
        public virtual Branches Industry2Navigation { get; set; }
    }
}
