using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntPhoneNumbers
    {
        public EntPhoneNumbers()
        {
            RelPhoneNumbersContacts = new HashSet<RelPhoneNumbersContacts>();
        }

        public string UserIdlastChange { get; set; }
        public string PnId { get; set; }
        public string PnType { get; set; }
        public string PnNumber { get; set; }
        public string PnName { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }

        public ICollection<RelPhoneNumbersContacts> RelPhoneNumbersContacts { get; set; }
    }
}
