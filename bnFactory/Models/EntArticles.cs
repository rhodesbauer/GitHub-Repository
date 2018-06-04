using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntArticles
    {
        public EntArticles()
        {
            EntArticleMetaData = new HashSet<EntArticleMetaData>();
        }

        public string ArtId { get; set; }
        public int ArtCode { get; set; }
        public string CatId { get; set; }
        public string ConId { get; set; }
        public string ArtTitle { get; set; }
        public string ArtUnderTitle { get; set; }
        public string ArtContent { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntCategories Cat { get; set; }
        public EntContacts Con { get; set; }
        public ICollection<EntArticleMetaData> EntArticleMetaData { get; set; }
    }
}
