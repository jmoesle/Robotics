using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class TypesInRelation
    {
        public int Id { get; set; }
        public int Types { get; set; }
        public int? Roboticsprinciples { get; set; }
        public int? Modesoflocomotion { get; set; }

        public virtual ModesOfLocomotion ModesoflocomotionNavigation { get; set; }
        public virtual RoboticsPrinciples RoboticsprinciplesNavigation { get; set; }
        public virtual Types TypesNavigation { get; set; }
    }
}
