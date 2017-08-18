using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfoSourcesInRelation
    {
        public int Id { get; set; }
        public string Tablename { get; set; }
        public int Tableid { get; set; }
        public int Infotype { get; set; }
        public int Infosourceid { get; set; }


        public virtual InfoTypes InfotypesNavigation { get; set; }
    }
}
