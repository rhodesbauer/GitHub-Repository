using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntTypes
    {
        public EntTypes()
        {
            EntAccounts = new HashSet<EntAccounts>();
            EntCategories = new HashSet<EntCategories>();
        }

        public string TypId { get; set; }
        public bool? TypAllowChange { get; set; }
        public int TypCode { get; set; }
        public string TypName { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<EntAccounts> EntAccounts { get; set; }
        public ICollection<EntCategories> EntCategories { get; set; }
    }
}
