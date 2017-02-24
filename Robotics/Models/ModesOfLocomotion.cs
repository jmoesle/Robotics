using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class ModesOfLocomotion
    {
        public ModesOfLocomotion()
        {
            ModesOfLocomotionTrans = new HashSet<ModesOfLocomotionTrans>();
            SpecificRobotsInRelation = new HashSet<SpecificRobotsInRelation>();
            TypesInRelation = new HashSet<TypesInRelation>();
        }

        public int Id { get; set; }

        public virtual ICollection<ModesOfLocomotionTrans> ModesOfLocomotionTrans { get; set; }
        public virtual ICollection<SpecificRobotsInRelation> SpecificRobotsInRelation { get; set; }
        public virtual ICollection<TypesInRelation> TypesInRelation { get; set; }
    }
}
