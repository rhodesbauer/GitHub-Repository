using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelBillGrouping
    {
        public string BgrId { get; set; }
        public string BilId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntBillGroup Bgr { get; set; }
        public EntBill Bil { get; set; }
    }
}
