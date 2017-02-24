using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class AddressesInRelation
    {
        public int Id { get; set; }
        public string Tablename { get; set; }
        public int Tableid { get; set; }
        public int Addresses { get; set; }

        public virtual Addresses AddressesNavigation { get; set; }
    }
}
