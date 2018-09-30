using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntCategories : BasicModel
    {
        public EntCategories()
        {
            EntArticles = new HashSet<EntArticles>();
            EntQuickEntry = new HashSet<EntQuickEntry>();
            RelCategoryBill = new HashSet<RelCategoryBill>();
        }

        [Key]
        public string CatId { get; set; }
        [ForeignKey("Typ")]
        public string TypId { get; set; }
        [Required]
        public string CatName { get; set; }
        public int CatCode { get; }
        public string CatFriendlyCode { get; set; }

        public EntTypes Typ { get; set; }
        public ICollection<EntArticles> EntArticles { get; set; }
        public ICollection<EntQuickEntry> EntQuickEntry { get; set; }
        public ICollection<RelCategoryBill> RelCategoryBill { get; set; }
    }
}
