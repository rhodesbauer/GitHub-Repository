using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntArticles : BasicModel
    {
        public EntArticles()
        {
            EntArticleMetaData = new HashSet<EntArticleMetaData>();
        }

        [Key]
        public string ArtId { get; set; }
        public int ArtCode { get; }
        [ForeignKey("Cat")]
        public string CatId { get; set; }
        [ForeignKey("Con")]
        public string ConId { get; set; }
        [Required]
        public string ArtTitle { get; set; }
        public string ArtUnderTitle { get; set; }
        public string ArtContent { get; set; }

        public EntCategories Cat { get; set; }
        public EntContacts Con { get; set; }
        public ICollection<EntArticleMetaData> EntArticleMetaData { get; set; }
    }
}
