using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfoSourcesInRelation
    {
        public int Id { get; set; }
        public string Tablename { get; set; }
        public int Tableid { get; set; }
        public int Infosources { get; set; }

        public virtual InfoSources InfosourcesNavigation { get; set; }
    }
}
