using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Types
    {
        public Types()
        {
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
            TypesInRelation = new HashSet<TypesInRelation>();
            TypesTrans = new HashSet<TypesTrans>();
        }

        public int Id { get; set; }

        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
        public virtual ICollection<TypesInRelation> TypesInRelation { get; set; }
        public virtual ICollection<TypesTrans> TypesTrans { get; set; }
    }
}
