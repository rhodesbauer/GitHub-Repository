using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntBillGroup
    {
        public EntBillGroup()
        {
            RelBillGrouping = new HashSet<RelBillGrouping>();
        }

        public string BgrId { get; set; }
        public int BgrTotalInstallments { get; set; }
        public DateTime BgrDateOfFirstInstallment { get; set; }
        public DateTime BgrDateOfFinalInstallment { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<RelBillGrouping> RelBillGrouping { get; set; }
    }
}
