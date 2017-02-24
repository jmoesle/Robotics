using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfluentialPeopleTrans
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
        public int Influentialpeople { get; set; }
        public int Language { get; set; }

        public virtual InfluentialPeople InfluentialpeopleNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
