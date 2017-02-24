using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            AddressesInRelation = new HashSet<AddressesInRelation>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string Streetnumber { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public int? Country { get; set; }

        public virtual ICollection<AddressesInRelation> AddressesInRelation { get; set; }
        public virtual Countries CountryNavigation { get; set; }
    }
}
