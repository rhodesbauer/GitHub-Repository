using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntArticleMetaData : BasicModel
    {
        [Key]
        public string AmdId { get; set; }
        [ForeignKey("Art")]
        public string ArtId { get; set; }
        public DateTime? AmdPublishDate { get; set; }
        public string ArtIdParent { get; set; }

        public EntArticles Art { get; set; }
    }
}
