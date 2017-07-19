using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class RelatedBusiness
    {
        public int Id { get; set; }
        public int Business1 { get; set; }
        public int Business2 { get; set; }

        public virtual Business Business1Navigation { get; set; }
        public virtual Business Business2Navigation { get; set; }
    }
}
