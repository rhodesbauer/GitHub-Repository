using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntBill
    {
        public EntBill()
        {
            EntBillDetails = new HashSet<EntBillDetails>();
            RelBillGrouping = new HashSet<RelBillGrouping>();
            RelCategoryBill = new HashSet<RelCategoryBill>();
        }

        public string BilId { get; set; }
        public int BilCode { get; set; }
        public decimal? BilValue { get; set; }
        public decimal? BilMultiplicator { get; set; }
        public string ConId { get; set; }
        public DateTime? BilDateExpiration { get; set; }
        public DateTime? BilDateOfWarning { get; set; }
        public int? BilRecurrence { get; set; }
        public string StaId { get; set; }
        public string AccId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntAccounts Acc { get; set; }
        public EntContacts Con { get; set; }
        public EntStatus Sta { get; set; }
        public ICollection<EntBillDetails> EntBillDetails { get; set; }
        public ICollection<RelBillGrouping> RelBillGrouping { get; set; }
        public ICollection<RelCategoryBill> RelCategoryBill { get; set; }
    }
}
