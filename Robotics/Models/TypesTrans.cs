using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class TypesTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Language { get; set; }
        public int Types { get; set; }

        public virtual Languages LanguageNavigation { get; set; }
        public virtual Types TypesNavigation { get; set; }
    }
}
