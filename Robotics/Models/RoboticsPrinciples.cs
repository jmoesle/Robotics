using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RoboticsPrinciples
    {
        public RoboticsPrinciples()
        {
            RoboticsPrinciplesTrans = new HashSet<RoboticsPrinciplesTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
            TypesInRelation = new HashSet<TypesInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<RoboticsPrinciplesTrans> RoboticsPrinciplesTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
        public virtual ICollection<TypesInRelation> TypesInRelation { get; set; }
    }
}
