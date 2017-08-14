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
        public string State { get; set; }
        public int? Country { get; set; }

        [RegularExpression(@"^\d+\.\d{0,6}$")]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        [RegularExpression(@"^\d+\.\d{0,6}$")]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
        public string Label { get; set; }

        public virtual ICollection<AddressesInRelation> AddressesInRelation { get; set; }
        public virtual Countries CountryNavigation { get; set; }
    }
}
