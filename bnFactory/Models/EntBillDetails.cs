using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntBillDetails
    {
        public string BdtId { get; set; }
        public string BilId { get; set; }
        public decimal BdtTotalValue { get; set; }
        public decimal? BdtDiscount { get; set; }
        public decimal? BdtInterest { get; set; }
        public decimal? BdtFine { get; set; }
        public DateTime BdtDateOfRegistration { get; set; }
        public string BtdObservation { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntBill Bil { get; set; }
    }
}
