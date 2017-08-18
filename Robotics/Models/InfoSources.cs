using System;
using System.Collections.Generic;

namespace Robotics.Models
{
    public partial class InfoSources
    { 

        public int Id { get; set; }
        public int? Books { get; set; }
        public int? Series { get; set; }
        public int? Journals { get; set; }
        public int? Collections { get; set; }
        public int? Unpublished { get; set; }
        public int? Newspapers { get; set; }
        public int? Officialstatements { get; set; }
        public int? Websites { get; set; }

        public virtual Books BooksNavigation { get; set; }
        public virtual Collections CollectionsNavigation { get; set; }
        public virtual Journals JournalsNavigation { get; set; }
        public virtual Newspapers NewspapersNavigation { get; set; }
        public virtual OfficialStatements OfficialstatementsNavigation { get; set; }
        public virtual Series SeriesNavigation { get; set; }
        public virtual Unpublished UnpublishedNavigation { get; set; }
        public virtual Websites WebsitesNavigation { get; set; }
    }
}
