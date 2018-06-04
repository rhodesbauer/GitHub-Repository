using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntQuickEntry
    {
        public string QenId { get; set; }
        public string QenGroupId { get; set; }
        public int QenCode { get; set; }
        public string CatId { get; set; }
        public string AccId { get; set; }
        public decimal QenValue { get; set; }
        public DateTime QenDateActivation { get; set; }
        public int? QenInstallmentNumber { get; set; }
        public int? QenTotalInstallments { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntAccounts Acc { get; set; }
        public EntCategories Cat { get; set; }
    }
}
