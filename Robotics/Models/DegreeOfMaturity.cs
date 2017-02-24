using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class DegreeOfMaturity
    {
        public DegreeOfMaturity()
        {
            DegreeOfMaturityTrans = new HashSet<DegreeOfMaturityTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<DegreeOfMaturityTrans> DegreeOfMaturityTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
    }
}
