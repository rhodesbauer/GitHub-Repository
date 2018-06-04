using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntStatus
    {
        public EntStatus()
        {
            EntBill = new HashSet<EntBill>();
        }

        public string StaId { get; set; }
        public int StaCode { get; set; }
        public string StaName { get; set; }
        public string StaDescription { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<EntBill> EntBill { get; set; }
    }
}
