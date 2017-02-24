using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class DegreeOfMaturityTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degreeofmaturity { get; set; }
        public int Language { get; set; }

        public virtual DegreeOfMaturity DegreeofmaturityNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
