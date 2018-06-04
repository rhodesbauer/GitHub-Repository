using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntCategories
    {
        public EntCategories()
        {
            EntArticles = new HashSet<EntArticles>();
            EntQuickEntry = new HashSet<EntQuickEntry>();
            RelCategoryBill = new HashSet<RelCategoryBill>();
        }

        public string CatId { get; set; }
        public string TypId { get; set; }
        public string CatName { get; set; }
        public int CatCode { get; set; }
        public string CatFriendlyCode { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntTypes Typ { get; set; }
        public ICollection<EntArticles> EntArticles { get; set; }
        public ICollection<EntQuickEntry> EntQuickEntry { get; set; }
        public ICollection<RelCategoryBill> RelCategoryBill { get; set; }
    }
}
