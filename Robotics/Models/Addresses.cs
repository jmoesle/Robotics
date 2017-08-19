using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string City { get; set; }
        public string State { get; set; }
        public int? Country { get; set; }

        [RegularExpression(@"^\d+\.\d{0,9}$")]
        public string Latitude { get; set; }
        /// <Latitude>
        /// Latitude must be between 90 and -90
        /// </Latitude>

        [RegularExpression(@"^\d+\.\d{0,9}$")]
        public string Longitude { get; set; }
        /// <Longitude>
        /// Longitude must be between 180 and -180
        /// </Longitude>
        public string Label { get; set; }

        public virtual ICollection<AddressesInRelation> AddressesInRelation { get; set; }
        public virtual Countries CountryNavigation { get; set; }
    }
}
