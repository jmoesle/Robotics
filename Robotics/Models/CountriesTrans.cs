using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class CountriesTrans
    {
        public int Id { get; set; }
        public int Countries { get; set; }
        public string Name { get; set; }
        public int Language { get; set; }

        public virtual Countries CountriesNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
