using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RelatedIndustries
    {
        public int Id { get; set; }
        public int Industry1 { get; set; }
        public int Industry2 { get; set; }

        public virtual Industries Industry1Navigation { get; set; }
        public virtual Industries Industry2Navigation { get; set; }
    }
}
