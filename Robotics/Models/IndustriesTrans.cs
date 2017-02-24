using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class IndustriesTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Industries { get; set; }
        public int Language { get; set; }

        public virtual Industries IndustriesNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
