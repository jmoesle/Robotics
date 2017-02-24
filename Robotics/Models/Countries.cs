using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Addresses = new HashSet<Addresses>();
            CountriesTrans = new HashSet<CountriesTrans>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<CountriesTrans> CountriesTrans { get; set; }
    }
}
