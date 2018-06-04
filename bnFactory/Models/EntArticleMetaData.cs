using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntArticleMetaData
    {
        public string AmdId { get; set; }
        public string ArtId { get; set; }
        public DateTime? AmdPublishDate { get; set; }
        public string ArtIdParent { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntArticles Art { get; set; }
    }
}
