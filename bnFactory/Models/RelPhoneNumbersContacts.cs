using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelPhoneNumbersContacts
    {
        public string PnId { get; set; }
        public string ConId { get; set; }
        public string UserIdlastChange { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }

        public EntContacts Con { get; set; }
        public EntPhoneNumbers Pn { get; set; }
    }
}
