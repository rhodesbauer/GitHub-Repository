using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntAccounts
    {
        public EntAccounts()
        {
            EntAccountDetails = new HashSet<EntAccountDetails>();
            EntBill = new HashSet<EntBill>();
            EntQuickEntry = new HashSet<EntQuickEntry>();
        }

        public string AccId { get; set; }
        public string AccName { get; set; }
        public int AccCode { get; set; }
        public string TypId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntTypes Typ { get; set; }
        public ICollection<EntAccountDetails> EntAccountDetails { get; set; }
        public ICollection<EntBill> EntBill { get; set; }
        public ICollection<EntQuickEntry> EntQuickEntry { get; set; }
    }
}
