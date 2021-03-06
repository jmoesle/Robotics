﻿using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class BusinessTrans
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Business { get; set; } 

        public int Language { get; set; }

        public virtual Business BusinessNavigation { get; set; }
        public virtual Languages LanguageNavigation { get; set; }
    }
}
